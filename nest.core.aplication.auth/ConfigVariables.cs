namespace nest.core.aplication.auth
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
    }
}
