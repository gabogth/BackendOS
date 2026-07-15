using Pulumi;
using Aws = Pulumi.Aws;

namespace nest.iac.servicesinfra.Resources
{
    public class ApiGatewayCreator
    {
        private readonly string nameVpcLink;
        private readonly string nameIntegration;
        private readonly string nameRoute;
        private readonly string prefix;
        private readonly string routePath;
        private readonly string permissionName;
        private Aws.LB.Listener listener;
        private Aws.ApiGatewayV2.VpcLink vpcLink = null!;
        private Aws.ApiGatewayV2.Integration integration = null!;
        private Aws.ApiGatewayV2.Route route = null!;
        private Aws.Lambda.Function lambda = null!;
        private Aws.Lambda.Permission permission = null!;
        public Output<string> ExecutionArn()
        {
            Output<Aws.ApiGatewayV2.GetApiResult> currentApi = Aws.ApiGatewayV2.GetApi.Invoke(new Aws.ApiGatewayV2.GetApiInvokeArgs { 
                ApiId = ConfigVariables.AwsApiId
            });
            return currentApi.Apply((x) => x.ExecutionArn);
        }
        public Output<string> EndpointUrl()
        {
            Output<Aws.ApiGatewayV2.GetApiResult> currentApi = Aws.ApiGatewayV2.GetApi.Invoke(new Aws.ApiGatewayV2.GetApiInvokeArgs
            {
                ApiId = ConfigVariables.AwsApiId
            });
            return currentApi.Apply((x) => x.ApiEndpoint);
        }
        public ApiGatewayCreator(string prefix, Aws.LB.Listener listener, string routePath)
        {
            this.prefix = prefix;
            this.nameVpcLink = $"{this.prefix}-vpcLink";
            this.nameIntegration = $"{this.prefix}-integration";
            this.nameRoute = $"{this.prefix}-route";
            this.listener = listener;
            this.routePath = routePath;
        }

        public ApiGatewayCreator(string prefix, Aws.Lambda.Function lambda, string routePath)
        {
            this.prefix = prefix;
            this.nameIntegration = $"{this.prefix}-integration";
            this.nameRoute = $"{this.prefix}-route";
            this.permissionName = $"{this.prefix}-permission";
            this.lambda = lambda;
            this.routePath = routePath;
        }

        public ApiGatewayCreator()
        {
            
        }

        public Aws.ApiGatewayV2.Route Build()
        {
            this.vpcLink = this.CreateVpcLink();
            this.integration = this.CreateIntegration();
            this.route = this.CreateRoutes();
            return this.route;
        }

        public Aws.ApiGatewayV2.Route BuildLambda()
        {
            this.permission = this.CreatePermissionLambda();
            this.integration = this.CreateIntegrationAws();
            this.route = this.CreateRoutes();
            return this.route;
        }
        private Aws.ApiGatewayV2.VpcLink CreateVpcLink()
        {
            return new Aws.ApiGatewayV2.VpcLink(nameVpcLink, new Aws.ApiGatewayV2.VpcLinkArgs {
                Name = nameVpcLink,
                SecurityGroupIds = ConfigVariables.AwsSecurityGroups,
                SubnetIds = ConfigVariables.AwsSubnets
            });
        }

        private Aws.ApiGatewayV2.Integration CreateIntegration()
        {
            return new Aws.ApiGatewayV2.Integration(nameIntegration, new Aws.ApiGatewayV2.IntegrationArgs {
                ApiId = ConfigVariables.AwsApiId,
                IntegrationType = "HTTP_PROXY",
                IntegrationUri = this.listener.Arn,
                IntegrationMethod = "ANY",
                ConnectionType = "VPC_LINK",
                ConnectionId = this.vpcLink.Id
            });
        }

        private Aws.ApiGatewayV2.Integration CreateIntegrationAws()
        {
            return new Aws.ApiGatewayV2.Integration(nameIntegration, new Aws.ApiGatewayV2.IntegrationArgs
            {
                ApiId = ConfigVariables.AwsApiId,
                IntegrationType = "AWS_PROXY",
                IntegrationUri = this.lambda.Arn,
                PayloadFormatVersion = "2.0"
            });
        }

        private Aws.Lambda.Permission CreatePermissionLambda()
        {
            var sourceArnPattern = this.routePath.EndsWith("/")
                ? $"{this.routePath}*"
                : $"{this.routePath}*";
            return new Aws.Lambda.Permission(this.permissionName, new Aws.Lambda.PermissionArgs
            {
                Action = "lambda:InvokeFunction",
                Function = this.lambda.Name,
                Principal = "apigateway.amazonaws.com",
                SourceArn = Output.Format($"{this.ExecutionArn()}/*/*{sourceArnPattern}")
            });
        }

        private Aws.ApiGatewayV2.Route CreateRoutes()
        {
            string mainRute = $"{nameRoute}-main";
            new Aws.ApiGatewayV2.Route(mainRute, new Aws.ApiGatewayV2.RouteArgs
            {
                ApiId = ConfigVariables.AwsApiId,
                RouteKey = $"ANY {this.routePath}",
                Target = this.integration.Id.Apply(integrationId => $"integrations/{integrationId}")
            });
            return new Aws.ApiGatewayV2.Route(nameRoute, new Aws.ApiGatewayV2.RouteArgs {
                ApiId = ConfigVariables.AwsApiId,
                RouteKey = $"ANY {this.routePath}/{{proxy+}}",
                Target = this.integration.Id.Apply(integrationId => $"integrations/{integrationId}") 
		    });
        }

        private Aws.ApiGatewayV2.Route CreateMain()
        {
            string mainRute = $"{nameRoute}-main";
            new Aws.ApiGatewayV2.Route(mainRute, new Aws.ApiGatewayV2.RouteArgs
            {
                ApiId = ConfigVariables.AwsApiId,
                RouteKey = $"ANY {this.routePath}",
                Target = this.integration.Id.Apply(integrationId => $"integrations/{integrationId}")
            });
            return new Aws.ApiGatewayV2.Route(nameRoute, new Aws.ApiGatewayV2.RouteArgs
            {
                ApiId = ConfigVariables.AwsApiId,
                RouteKey = $"ANY {this.routePath}/{{proxy+}}",
                Target = this.integration.Id.Apply(integrationId => $"integrations/{integrationId}")
            });
        }
    }
}
