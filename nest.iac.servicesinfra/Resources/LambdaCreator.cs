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
        private bool isEventBridgeAttached = false;
        public LambdaCreator(string lambdaName, Awsx.Ecr.Image image, string basePath, Aws.Iam.Role role, string cwName, bool isEventBridgeAttached, Output<string> endpointUrl)
        {
            this.lambdaName = lambdaName;
            this.image = image;
            this.basePath = basePath;
            this.role = role;
            this.cwName = cwName;
            this.endpointUrl = endpointUrl;
            this.isEventBridgeAttached = isEventBridgeAttached;
        }
        public Aws.Lambda.Function Build()
        {
            this.function = this.Create();
            CreateCW();
            if(this.isEventBridgeAttached)
                AttachEventBridge();
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

        public Aws.CloudWatch.EventRule AttachEventBridge()
        {
            string permissionName = $"{this.lambdaName}-permission";
            string eventName = $"{this.lambdaName}-event";
            string targetName = $"{this.lambdaName}-target";
            var rule = new Aws.CloudWatch.EventRule(eventName, new Aws.CloudWatch.EventRuleArgs
            {
                Name = eventName,
                ScheduleExpression = "rate(5 minutes)",
                State = "ENABLED"
            });
            var permission = new Aws.Lambda.Permission(permissionName, new Aws.Lambda.PermissionArgs
            {
                Action = "lambda:InvokeFunction",
                Function = this.function.Arn,
                Principal = "events.amazonaws.com",
                SourceArn = rule.Arn
            });
            var target = new Aws.CloudWatch.EventTarget(targetName, new Aws.CloudWatch.EventTargetArgs
            {
                Arn = this.function.Arn,
                Rule = rule.Name,
            });
            return rule;
        }
    }
}
