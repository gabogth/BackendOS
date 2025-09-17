using nest.iac.servicesinfra.Resources;
using Pulumi;

namespace nest.iac.servicesinfra
{
    class Index : Stack
    {
        [Output("ecrUrl")] public Output<string> EcrUrl { get; set; }
        public Index()
        {
            //Nombre recursos
            string prefix = $"{Deployment.Instance.ProjectName}-security";
            string ecrName = $"{prefix}-ecr";

            //Recursos
            var ecsCluster = new EcrCreator(ecrName).Build();

            //Output
            EcrUrl = ecsCluster.Url;
        }

    }
}
