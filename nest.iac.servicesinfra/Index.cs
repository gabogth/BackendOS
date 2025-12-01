using nest.iac.servicesinfra.Entities;
using nest.iac.servicesinfra.Resources;
using Pulumi;

namespace nest.iac.servicesinfra
{
    class Index : Stack
    {
        public Index()
        {
            ApiGatewayCreator api = new ApiGatewayCreator();
            ServiceConfig[] services = ConfigVariables.AwsServices;
            for (int i = 0; i < services.Length; i++)
            {
                ServiceConfig currentService = services[i];
                string prefix = $"{Deployment.Instance.ProjectName}-{currentService.serviceName}";
                string lambdaName = $"{prefix}-lambda";
                string prefixShort = currentService.serviceName;
                string ecrName = $"{prefix}-ecr";
                string imageName = $"{prefix}-image";
                string lambdaRoleName = $"{prefix}-lambda-role";
                string cwName = $"{prefix}-cw";
                string stageMain = "$default";
                string routePath = currentService.routepath;
                var ecrImage2 = new EcrCreator(ecrName, imageName, currentService.contextDocker, currentService.pathProject, "latest").Build();
                var lambdaRole = new RoleCreator(lambdaRoleName, prefix, Deployment.Instance.ProjectName).BuildLambda();
                var lambda = new LambdaCreator(lambdaName, routePath, lambdaRole, cwName, api.EndpointUrl()).Build();
                var route2 = new ApiGatewayCreator(prefix, stageMain, lambda, routePath, i == 0).BuildLambda();
            }
            //var tableName = CreateDynamoDbTable();
            CreateHealthCheck();
        }

        private void CreateHealthCheck()
        {
            string healthPrefix = $"{Deployment.Instance.ProjectName}-healthcheck";
            string healthLambdaName = $"{Deployment.Instance.ProjectName}-healthcheck-lambda";
            string healthRoleName = $"{Deployment.Instance.ProjectName}-healthcheck-role";
            var healthLambdaRole = new RoleCreator(healthRoleName, healthPrefix, Deployment.Instance.ProjectName).BuildLambda();
            LambdaCreator.CreateHealthCheck(healthLambdaName, healthLambdaRole);
        }

        private string CreateDynamoDbTable()
        {
            string healthPrefix = $"{Deployment.Instance.ProjectName}-healthcheck";
            string healthTableName = $"{healthPrefix}-table";
            DynamoDbCreator creator = new DynamoDbCreator();
            creator.Build(healthTableName);
            return healthTableName;
        }
    }
}
