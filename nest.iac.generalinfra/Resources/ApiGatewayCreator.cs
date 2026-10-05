using Pulumi;
using Aws = Pulumi.Aws;

namespace nest.iac.generalinfra.Resources
{
    public class ApiGatewayCreator
    {
        private readonly string apiName;
        private Aws.ApiGatewayV2.Api api;
        private Aws.ApiGatewayV2.Stage stage;
        private readonly string nameIntegration;
        private readonly string nameRoute;
        private readonly string prefix;
        private readonly string routePath;
        private readonly string permissionName;
        private Aws.ApiGatewayV2.Integration integration = null!;
        private Aws.ApiGatewayV2.Route route = null!;
        private Aws.Lambda.Permission permission = null!;
        private Aws.Lambda.Function lambda = null!;
        public ApiGatewayCreator(string prefix, string apiName, string routePath)
        {
            this.apiName = apiName;
            this.routePath = routePath;
            this.prefix = prefix;
            
            this.nameIntegration = $"{this.prefix}-integration";
            this.nameRoute = $"{this.prefix}-route";
            this.permissionName = $"{this.prefix}-permission";
        }
        public Aws.ApiGatewayV2.Api Build()
        {
            api = Create(this.apiName);
            stage = AddStage($"{this.apiName}-stage", "$default", $"{this.apiName}-logs");
            return api;
        }

        public Aws.ApiGatewayV2.Route BuildLambda(Aws.Lambda.Function lambda)
        {
            this.lambda = lambda;
            this.permission = this.CreatePermissionLambda();
            this.integration = this.CreateIntegrationAws();
            this.route = this.CreateRoutes();
            return this.route;
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

        private Aws.Lambda.Permission CreatePermissionLambda()
        {
            var sourceArnPattern = this.routePath.EndsWith("/")
                ? $"{this.routePath}*"
                : $"{this.routePath}/*";
            return new Aws.Lambda.Permission(this.permissionName, new Aws.Lambda.PermissionArgs
            {
                Action = "lambda:InvokeFunction",
                Function = this.lambda.Name,
                Principal = "apigateway.amazonaws.com",
                SourceArn = Output.Format($"{this.ExecutionArn()}/*/*{sourceArnPattern}")
            });
        }
        private Aws.ApiGatewayV2.Integration CreateIntegrationAws()
        {
            return new Aws.ApiGatewayV2.Integration(nameIntegration, new Aws.ApiGatewayV2.IntegrationArgs
            {
                ApiId = this.api.Id,
                IntegrationType = "AWS_PROXY",
                IntegrationUri = this.lambda.Arn,
                PayloadFormatVersion = "2.0"
            });
        }

        private Aws.ApiGatewayV2.Route CreateRoutes()
        {
            string mainRute = $"{nameRoute}-main";
            new Aws.ApiGatewayV2.Route(mainRute, new Aws.ApiGatewayV2.RouteArgs
            {
                ApiId = this.api.Id,
                RouteKey = $"ANY {this.routePath}",
                Target = this.integration.Id.Apply(integrationId => $"integrations/{integrationId}")
            });
            return new Aws.ApiGatewayV2.Route(nameRoute, new Aws.ApiGatewayV2.RouteArgs
            {
                ApiId = this.api.Id,
                RouteKey = $"ANY {this.routePath}{{proxy+}}",
                Target = this.integration.Id.Apply(integrationId => $"integrations/{integrationId}")
            });
        }

        public Output<string> ExecutionArn()
        {
            Output<Aws.ApiGatewayV2.GetApiResult> currentApi = Aws.ApiGatewayV2.GetApi.Invoke(new Aws.ApiGatewayV2.GetApiInvokeArgs
            {
                ApiId = this.api.Id
            });
            return currentApi.Apply((x) => x.ExecutionArn);
        }
    }
}
