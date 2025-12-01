using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nest.core.dominio
{
    public static class ConfigVariables
    {
        public static string Engine { get { return GetString("ENGINE"); } }
        public static string ConnectionString { get { return GetString("Connections__Npgsql"); } }
        public static string BaseUrl { get { return GetString("BASE_URL"); } }
        public static bool IsLambda { get { return GetString("IS_LAMBDA") != null ? bool.Parse(GetString("IS_LAMBDA")) : false; } }
        public static string EndpointUrl { get { return GetString("URL_ENDPOINT"); } }
        public static string BucketName { get { return GetString("MAIN_BUCKET"); } }
        private static string GetString(string EnvironmentVariable)
        {
            string baseResult = Environment.GetEnvironmentVariable(EnvironmentVariable);
            if (string.IsNullOrWhiteSpace(baseResult))
                return null;
            return baseResult.Trim();
        }
        private static string GetServiceUrl(string service)
        {
            return EndpointUrl + "/" + service;
        }
        public static string ContabilidadService { get { return GetServiceUrl("contabilidad"); } }
        public static string CorporativoService { get { return GetServiceUrl("corporativo"); } }
        public static string CostosService { get { return GetServiceUrl("costos"); } }
        public static string DatasourceService { get { return GetServiceUrl("datasource"); } }
        public static string FinanzasService { get { return GetServiceUrl("finanzas"); } }
        public static string GeneralService { get { return GetServiceUrl("general"); } }
        public static string LegalService { get { return GetServiceUrl("legal"); } }
        public static string LogisticaService { get { return GetServiceUrl("logistica"); } }
        public static string ManttoService { get { return GetServiceUrl("mantto"); } }
        public static string PatrimonialService { get { return GetServiceUrl("patrimonial"); } }
        public static string RrhhService { get { return GetServiceUrl("rrhh"); } }
        public static string SecurityService { get { return GetServiceUrl("security"); } }
    }
}
