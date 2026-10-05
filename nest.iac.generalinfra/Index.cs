using nest.iac.generalinfra.Resources;
using Pulumi;
using System.Xml.Linq;

namespace nest.iac.generalinfra
{
    class Index : Stack
    {
        //[Output("ecsArn")] public Output<string> EcsArn { get; set; }
        [Output("rdsArn")] public Output<string> RdsArn { get; set; }
        [Output("rdsEndPoint")] public Output<string> RdsEndPoint { get; set; }
        [Output("apiEndpoint")] public Output<string> ApiEndpoint { get; set; }
        [Output("apiId")] public Output<string> ApiId { get; set; }
        [Output("bucketName")] public Output<string> BucketName { get; set; }

        public Index()
        {
            //Nombre recursos
            string ecsName = $"{Deployment.Instance.ProjectName}-clusterecs";
            string ecsCapacityName = $"{Deployment.Instance.ProjectName}-clusterecs-capacity";
            string subnetGroupName = $"{Deployment.Instance.ProjectName}-rdssubnetgroup";
            string rdsInstanceName = $"{Deployment.Instance.ProjectName}-instance";
            string apiGatewayName = $"{Deployment.Instance.ProjectName}-api";
            string bucketName = $"{Deployment.Instance.ProjectName}-bucket";
            string prefix = $"{Deployment.Instance.ProjectName}-services";
            string routePath = "/";

            //Recursos
            //var ecsCluster = new EcsCreator(ecsName, ecsCapacityName).Build();
            var rdsInstance = new RdsCreator(subnetGroupName, rdsInstanceName).Build();
            var bucket = new BucketCreator(bucketName).Build();
            var apiGatewayCreator = new ApiGatewayCreator(prefix, apiGatewayName, routePath);

            //Servicios
            string ecrName = $"{prefix}-ecr";
            string imageName = $"{prefix}-image";
            string lambdaName = $"{prefix}-lambda";
            string lambdaRoleName = $"{prefix}-lambda-role";
            string cwName = $"{prefix}-cw";
            var apiGateway = apiGatewayCreator.Build();
            var ecrImage2 = new EcrCreator(ecrName, imageName, "../", "../nest.core.security/lambda.Dockerfile", "latest").Build();
            var lambdaRole = new RoleCreator(lambdaRoleName, prefix, Deployment.Instance.ProjectName).BuildLambda();
            var lambda = new LambdaCreator(lambdaName, routePath, lambdaRole, cwName, apiGateway.ApiEndpoint, ecrImage2, bucketName).Build(true);
            var route = apiGatewayCreator.BuildLambda(lambda);

            //Outputs
            //EcsArn = ecsCluster.Arn;
            RdsArn = rdsInstance.Arn;
            RdsEndPoint = rdsInstance.Endpoint;
            ApiEndpoint = apiGateway.ApiEndpoint;
            ApiId = apiGateway.Id;
            BucketName = bucket.BucketName;
        }

    }
}
