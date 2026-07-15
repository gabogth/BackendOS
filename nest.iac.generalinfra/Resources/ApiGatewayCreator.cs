using Aws = Pulumi.Aws;

namespace nest.iac.generalinfra.Resources
{
    public class ApiGatewayCreator
    {
        private readonly string apiName;
        private Aws.ApiGatewayV2.Api api;
        private Aws.ApiGatewayV2.Stage stage;
        public ApiGatewayCreator(string apiName)
        {
            this.apiName = apiName;
        }
        public Aws.ApiGatewayV2.Api Build()
        {
            api = Create(this.apiName);
            stage = AddStage($"{this.apiName}-stage", "$default", $"{this.apiName}-logs");
            return api;
        }

        public Aws.ApiGatewayV2.Api Create(string Name)
        {
            return new Aws.ApiGatewayV2.Api(Name, new Aws.ApiGatewayV2.ApiArgs {
                Name = Name,
                ProtocolType = "HTTP",
                CorsConfiguration = new Aws.ApiGatewayV2.Inputs.ApiCorsConfigurationArgs { 
                    AllowHeaders = ["*"],
                    AllowMethods = ["*"],
                    AllowOrigins = ["*"]
                }
            });
        }

        public Aws.ApiGatewayV2.Stage AddStage(string nameStage, string stage, string nameLog)
        {
            var logGroup = CreateAccessLogs(nameLog);
            return new Aws.ApiGatewayV2.Stage(nameStage, new Aws.ApiGatewayV2.StageArgs
            {
                Name = stage,
                ApiId = this.api.Id,
                AutoDeploy = true,
                AccessLogSettings = new Aws.ApiGatewayV2.Inputs.StageAccessLogSettingsArgs
                {
                    DestinationArn = logGroup.Arn,
                    Format = "{\"requestId\":\"$context.requestId\", \"ip\":\"$context.identity.sourceIp\", \"requestTime\":\"$context.requestTime\", \"httpMethod\":\"$context.httpMethod\", \"routeKey\":\"$context.routeKey\", \"status\":\"$context.status\", \"protocol\":\"$context.protocol\", \"responseLength\":\"$context.responseLength\"}"
                }
            });
        }

        private Aws.CloudWatch.LogGroup CreateAccessLogs(string name)
        {
            return new Aws.CloudWatch.LogGroup(name, new Aws.CloudWatch.LogGroupArgs
            {
                Name = name,
                RetentionInDays = 1
            });
        }
    }
}
