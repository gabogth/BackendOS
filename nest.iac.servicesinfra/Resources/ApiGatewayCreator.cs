using Aws = Pulumi.Aws;

namespace nest.iac.servicesinfra.Resources
{
    public class ApiGatewayCreator
    {
        private readonly string apiName;
        public ApiGatewayCreator(string apiName)
        {
            this.apiName = apiName;
        }
        public Aws.ApiGatewayV2.Api Build()
        {
            Aws.ApiGatewayV2.Api api = Create(this.apiName);
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
    }
}
