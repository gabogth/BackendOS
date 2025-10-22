using nest.iac.generalinfra.Resources;
using Pulumi;

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

            //Recursos
            //var ecsCluster = new EcsCreator(ecsName, ecsCapacityName).Build();
            var rdsInstance = new RdsCreator(subnetGroupName, rdsInstanceName).Build();
            var apiGateway = new ApiGatewayCreator(apiGatewayName).Build();
            var bucket = new BucketCreator(bucketName).Build();

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
