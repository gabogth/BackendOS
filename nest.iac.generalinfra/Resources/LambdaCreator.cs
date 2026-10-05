using Pulumi;
using Aws = Pulumi.Aws;
using Awsx = Pulumi.Awsx;

namespace nest.iac.generalinfra.Resources
{
    public class LambdaCreator
    {
        public string lambdaName { get; set; }
        public string cwName { get; set; }
        public Awsx.Ecr.Image image { get; set; }
        private string basePath { get; set; }
        private Aws.Iam.Role role = null!;
        private Aws.Lambda.Function function = null!;
        private Output<string> endpointUrl { get; set; }
        private string bucketName { get; set; }
        public LambdaCreator(string lambdaName, string basePath, Aws.Iam.Role role, string cwName, Output<string> endpointUrl, Awsx.Ecr.Image image, string bucketName)
        {
            this.lambdaName = lambdaName;
            this.image = image;
            this.basePath = basePath;
            this.role = role;
            this.cwName = cwName;
            this.endpointUrl = endpointUrl;
            this.bucketName = bucketName;
        }
        public Aws.Lambda.Function Build(bool createHealthCheck)
        {
            this.function = this.Create();
            CreateCW();
            if (createHealthCheck)
                CreateHealthCheck();
            return function;
        }
        private Aws.Lambda.Function Create()
        {
            var envVariables = new InputMap<string>
            {
                { "ASPNETCORE_ENVIRONMENT", "Production" },
                { "ENGINE", "Npgsql" },
                { "Connections__Npgsql", ConfigVariables.ConnectionString },
                { "BASE_URL", this.basePath },
                { "IS_LAMBDA", "True" },
                { "URL_ENDPOINT", this.endpointUrl },
                { "MAIN_BUCKET", this.bucketName },
                { "TZ", "America/Lima" },
                { "Logging__LogLevel__Default", "Information" },
                { "Logging__LogLevel__Microsoft__AspNetCore", "Warning" },
                { "Logging__LogLevel__Microsoft__EntityFrameworkCore", "Warning" },
                { "Logging__LogLevel__Microsoft__EntityFrameworkCore__Database__Command", "Warning" },
            };

            return new Aws.Lambda.Function(this.lambdaName, new Aws.Lambda.FunctionArgs
            {
                Name = this.lambdaName,
                PackageType = "Image",
                ImageUri = this.image.ImageUri,
                MemorySize = 512,
                Timeout = 120,
                Role = this.role.Arn,
                Environment = new Aws.Lambda.Inputs.FunctionEnvironmentArgs
                {
                    Variables = envVariables
                },
            });
        }

        private void CreateCW()
        {
            var lg = new Aws.CloudWatch.LogGroup(this.cwName, new Aws.CloudWatch.LogGroupArgs
            {
                Name = this.function.Name.Apply(name => $"/aws/lambda/{name}"),
                RetentionInDays = 1
            });
        }

        public Aws.Lambda.Function CreateHealthCheck()
        {
            var lambdaCode = @"
                    const { LambdaClient, InvokeCommand } = require(""@aws-sdk/client-lambda"");

                    const lambdaClient = new LambdaClient({});

                    const payload = Buffer.from(JSON.stringify({
                      version: ""2.0"",
                      routeKey: ""$default"",
                      rawPath: ""/health/live"",
                      requestContext: { http: { method: ""GET"", path: ""/health/live"" } }
                    }));

                    exports.handler = async () => {
                      console.log(""executed at:"", new Date().toISOString());
                      const arns = process.env.TARGET_ARNS.split("","");
                      const promises = arns.map(async (arn) => {
                        // Invocar Lambda
                        const res = await lambdaClient.send(new InvokeCommand({
                          FunctionName: arn.trim(),
                          Payload: payload,
                          InvocationType: ""RequestResponse""
                        }));
                        const resultPayload = Buffer.from(res.Payload).toString();
                        console.log(`""Response from ${arn}: ${resultPayload}""`);
                      });
                      await Promise.all(promises);
                    };";

            var arns = $"arn:aws:lambda:{ConfigVariables.Region}:{ConfigVariables.AwsAccountId}:function:{this.lambdaName}";
            var currLambdaName = $"{Deployment.Instance.ProjectName}-healthcheck-lambda";
            var lambda = new Aws.Lambda.Function(currLambdaName, new Aws.Lambda.FunctionArgs
            {
                Name = currLambdaName,
                Runtime = "nodejs22.x",
                Handler = "index.handler",
                Role = this.role.Arn,
                Code = new AssetArchive(new Dictionary<string, AssetOrArchive>
                {
                    { "index.js", new StringAsset(lambdaCode) }
                }),
                Timeout = 120,
                MemorySize = 512,
                Environment = new Aws.Lambda.Inputs.FunctionEnvironmentArgs
                {
                    Variables =
                    {
                        { "TARGET_ARNS", arns },
                        { "TZ", "America/Lima" }
                    }
                }
            });

            AttachEventBridge(lambda);

            return lambda;
        }

        private Aws.CloudWatch.EventRule AttachEventBridge(Aws.Lambda.Function healthCheck)
        {
            string permissionName = $"{this.lambdaName}-permission";
            string eventName = $"{this.lambdaName}-event";
            string targetName = $"{this.lambdaName}-target";
            var rule = new Aws.CloudWatch.EventRule(eventName, new Aws.CloudWatch.EventRuleArgs
            {
                Name = eventName,
                ScheduleExpression = "rate(1 minute)",
                State = "ENABLED"
            });
            var permission = new Aws.Lambda.Permission(permissionName, new Aws.Lambda.PermissionArgs
            {
                Action = "lambda:InvokeFunction",
                Function = healthCheck.Arn,
                Principal = "events.amazonaws.com",
                SourceArn = rule.Arn
            });
            var target = new Aws.CloudWatch.EventTarget(targetName, new Aws.CloudWatch.EventTargetArgs
            {
                Arn = healthCheck.Arn,
                Rule = rule.Name,
            });
            return rule;
        }
    }
}
