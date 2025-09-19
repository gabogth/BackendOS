using nest.iac.servicesinfra.Entities;
using nest.iac.servicesinfra.Resources;
using Pulumi;

namespace nest.iac.servicesinfra
{
    class Index : Stack
    {
        public Index()
        {
            ServiceConfig[] services = ConfigVariables.AwsServices;
            for (int i = 0; i < services.Length; i++)
            {
                ServiceConfig currentService = services[i];
                string prefix = $"{Deployment.Instance.ProjectName}-{currentService.serviceName}";
                string prefixShort = currentService.serviceName;
                string ecrName = $"{prefix}-ecr";
                string imageName = $"{prefix}-image";
                string taskRoleName = $"{prefix}-task-role";
                string executionRoleName = $"{prefix}-exec-role";
                string cloudwatchName = $"{prefix}-cw";
                string stageMain = "$default";
                string routePath = currentService.routepath;

                var ecrImage = new EcrCreator(ecrName, imageName, currentService.contextDocker, currentService.pathProject, "latest").Build();
                var (executionRole, taskRole) = new RoleCreator(executionRoleName, taskRoleName, prefix, Deployment.Instance.ProjectName).Build();
                var cloudwatch = new CwCreator(cloudwatchName).Build();
                var (listener, service) = new FargateCreator(prefix, prefixShort, executionRole, taskRole, ecrImage, cloudwatch, 8080, routePath).Build();
                var route = new ApiGatewayCreator(prefix, stageMain, listener, routePath, i == 0).Build();
            }
        }
    }
}
