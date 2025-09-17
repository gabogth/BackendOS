using Pulumi;

namespace nest.iac.generalinfra.Resources
{
    public class ConfigVariables
    {
        private static Config ConfigRds = new Config("rds");
        private static Config ConfigAws = new Config("cld");
        public static string ProjectName { get { return Deployment.Instance.ProjectName; } }
        public static string RdsEngine { get { return ConfigRds.Require("engine"); } }
        public static string RdsInstanceClass { get { return ConfigRds.Require("instanceClass"); } }
        public static string RdsEngineVersion { get { return ConfigRds.Require("engineVersion"); } }
        public static string RdsStorageType { get { return ConfigRds.Require("storageType"); } }
        public static int RdsAllocatedStorage { get { return ConfigRds.RequireInt32("allocatedStorage"); } }
        public static string AwsVpcId { get { return ConfigAws.Require("vpcId"); } }
        public static string[] AwsSubnets { get { return ConfigAws.RequireObject<string[]>("subnets"); } }
        public static string[] AwsSecurityGroups { get { return ConfigAws.RequireObject<string[]>("securityGroups"); } }
        public static string RdsDatabaseName { get { return Environment.GetEnvironmentVariable("DATABASE_NAME") ?? throw new Exception("environment variable DATABASE_NAME is required"); } }
        public static string RdsMasterUser { get { return Environment.GetEnvironmentVariable("DATABASE_MASTERUSER") ?? throw new Exception("environment variable DATABASE_MASTERUSER is required"); } }
        public static string RdsMasterPw { get { return Environment.GetEnvironmentVariable("DATABASE_MASTERPW") ?? throw new Exception("environment variable DATABASE_MASTERPW is required"); } }
        public static int RdsDatabasePort { get { return int.Parse(Environment.GetEnvironmentVariable("DATABASE_PORT") ?? throw new Exception("environment variable DATABASE_PORT is required")); } }
    }
}
