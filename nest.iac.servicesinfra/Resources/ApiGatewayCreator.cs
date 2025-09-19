using Microsoft.AspNetCore.Routing;
using Pulumi;
using Pulumi.Aws.AppAutoScaling;
using Pulumi.Aws.CloudWatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Aws = Pulumi.Aws;
using Awsx = Pulumi.Awsx;

namespace nest.iac.servicesinfra.Resources
{
    public class ApiGatewayCreator
    {
        private readonly string nameVpcLink;
        private readonly string nameIntegration;
        private readonly string nameRoute;
        private readonly string nameStage;
        private readonly string stageMain;
        private readonly string prefix;
        private readonly string routePath;
        private Aws.LB.Listener listener;
        private Aws.ApiGatewayV2.VpcLink vpcLink = null!;
        private Aws.ApiGatewayV2.Integration integration = null!;
        private Aws.ApiGatewayV2.Route route = null!;
        private Aws.ApiGatewayV2.Stage stage = null!;
        private bool deploy = false;

        public ApiGatewayCreator(string prefix, string stageMain, Aws.LB.Listener listener, string routePath, bool deploy)
        {
            this.prefix = prefix;
            this.nameVpcLink = $"{this.prefix}-vpcLink";
            this.nameIntegration = $"{this.prefix}-integration";
            this.nameRoute = $"{this.prefix}-route";
            this.nameStage = $"{this.prefix}-stg";
            this.listener = listener;
            this.stageMain = stageMain;
            this.routePath = routePath;
            this.deploy = deploy;
        }

        public Aws.ApiGatewayV2.Route Build()
        {
            this.vpcLink = this.CreateVpcLink();
            this.integration = this.CreateIntegration();
            this.route = this.CreateRoutes();
            if(this.deploy)
                this.stage = this.CreateStageDeploy();
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

        private Aws.ApiGatewayV2.Route CreateRoutes()
        {
            return new Aws.ApiGatewayV2.Route(nameRoute, new Aws.ApiGatewayV2.RouteArgs {
                ApiId = ConfigVariables.AwsApiId,
                RouteKey = $"ANY {this.routePath}/{{proxy+}}",
                Target = this.integration.Id.Apply(integrationId => $"integrations/{integrationId}") 
		    });
        }

        private Aws.ApiGatewayV2.Stage CreateStageDeploy()
        {
            return new Aws.ApiGatewayV2.Stage(this.nameStage, new Aws.ApiGatewayV2.StageArgs {
                Name = this.stageMain,
                ApiId = ConfigVariables.AwsApiId,
                AutoDeploy = true
            });
	    }

    }
}
