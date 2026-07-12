using nest.iac.servicesinfra.Entities;
using Pulumi;
using Aws = Pulumi.Aws;
using Awsx = Pulumi.Awsx;

namespace nest.iac.servicesinfra.Resources
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
        public LambdaCreator(string lambdaName, string basePath, Aws.Iam.Role role, string cwName, Output<string> endpointUrl, Awsx.Ecr.Image image)
        {
            this.lambdaName = lambdaName;
            this.image = image;
            this.basePath = basePath;
            this.role = role;
            this.cwName = cwName;
            this.endpointUrl = endpointUrl;
        }
        public Aws.Lambda.Function Build()
        {
            this.function = this.Create();
            CreateCW();
            return function;
        }
        private Aws.Lambda.Function Create()
        {
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
                    Variables = 
                    {
                        { "ASPNETCORE_ENVIRONMENT", "Production" },
                        { "ENGINE", "Npgsql" },
                        { "Connections__Npgsql", ConfigVariables.ConnectionString },
                        { "BASE_URL", this.basePath },
                        { "IS_LAMBDA", "True" },
                        { "URL_ENDPOINT", this.endpointUrl },
                        { "MAIN_BUCKET", ConfigVariables.AwsBucketName },
                        { "TZ", "America/Lima" }
                    }
                },
                VpcConfig = new Aws.Lambda.Inputs.FunctionVpcConfigArgs
                {
                    SubnetIds = ConfigVariables.AwsSubnets,
                    SecurityGroupIds = ConfigVariables.AwsSecurityGroups
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

        public static Aws.CloudWatch.EventRule AttachEventBridge(string lambdaName, Aws.Lambda.Function function)
        {
            string permissionName = $"{lambdaName}-permission";
            string eventName = $"{lambdaName}-event";
            string targetName = $"{lambdaName}-target";
            var rule = new Aws.CloudWatch.EventRule(eventName, new Aws.CloudWatch.EventRuleArgs
            {
                Name = eventName,
                ScheduleExpression = "rate(1 minute)",
                State = "ENABLED"
            });
            var permission = new Aws.Lambda.Permission(permissionName, new Aws.Lambda.PermissionArgs
            {
                Action = "lambda:InvokeFunction",
                Function = function.Arn,
                Principal = "events.amazonaws.com",
                SourceArn = rule.Arn
            });
            var target = new Aws.CloudWatch.EventTarget(targetName, new Aws.CloudWatch.EventTargetArgs
            {
                Arn = function.Arn,
                Rule = rule.Name,
            });
            return rule;
        }

        public static Aws.Lambda.Function CreateHealthCheck(string currLambdaName, Aws.Iam.Role currRole)
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
            ServiceConfig[] services = ConfigVariables.AwsServices;
            string arns = string.Empty;

            foreach (var currentService in services)
            {
                if (!string.IsNullOrWhiteSpace(currentService.healthPath)) {
                    arns += (arns == string.Empty ? arns : ",")
                        + $"arn:aws:lambda:{ConfigVariables.Region}:{ConfigVariables.AwsAccountId}:function:{Deployment.Instance.ProjectName}-{currentService.serviceName}-lambda";
                }
            }
            var lambda = new Aws.Lambda.Function(currLambdaName, new Aws.Lambda.FunctionArgs
            {
                Name = currLambdaName,
                Runtime = "nodejs18.x",
                Handler = "index.handler",
                Role = currRole.Arn,
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

            AttachEventBridge(currLambdaName, lambda);

            return lambda;
        }
    }
}
