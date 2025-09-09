using Pulumi;
using Pulumi.Aws.Ec2;
using Aws = Pulumi.Aws;

namespace nest.iac.generalinfra.Resources
{
    public class RdsCreator
    {
        private readonly string subnetGroupName;
        private readonly string instanceName;
        private readonly SecurityGroupCreator securityGroupCreator;
        public RdsCreator(string subnetGroupName, string instanceName)
        {
            this.subnetGroupName = subnetGroupName;
            this.instanceName = instanceName;
            this.securityGroupCreator = new SecurityGroupCreator();
        }
        public Aws.Rds.Instance Build()
        {
            Aws.Rds.SubnetGroup subnetGroup = CreateSubnetsGroup(this.subnetGroupName);
            Aws.Rds.Instance instance = CreateInstance(this.instanceName, subnetGroup);
            return instance;
        }
        private Aws.Rds.SubnetGroup CreateSubnetsGroup(string name)
        {
            return new Aws.Rds.SubnetGroup(name, new Aws.Rds.SubnetGroupArgs
            {
                Name = name,
                SubnetIds = ConfigVariables.AwsSubnets
            });
        }

        private Aws.Rds.Instance CreateInstance(string name, Aws.Rds.SubnetGroup subnetGroup)
        {
            SecurityGroup sg = this.securityGroupCreator.CreatePublicSg($"{ConfigVariables.ProjectName}-public-sg");
            Output<string[]> rdsSgs = sg.Id.Apply((sgActual) =>
            {
                List<string> arr = new List<string>();
                arr.Add(sgActual);
                arr.AddRange(ConfigVariables.AwsSecurityGroups);
                return arr.ToArray();
            });

            return new Aws.Rds.Instance(name, new Aws.Rds.InstanceArgs
            {
                Identifier = name,
                Engine = ConfigVariables.RdsEngine,
                InstanceClass = ConfigVariables.RdsInstanceClass,
                EngineVersion = ConfigVariables.RdsEngineVersion,
                DbName = ConfigVariables.RdsDatabaseName,
                Username = ConfigVariables.RdsMasterUser,
                Password = ConfigVariables.RdsMasterPw,
                Port = ConfigVariables.RdsDatabasePort,
                StorageType = ConfigVariables.RdsStorageType,
                AllocatedStorage = ConfigVariables.RdsAllocatedStorage,
                StorageEncrypted = false,
                VpcSecurityGroupIds = rdsSgs,
                DbSubnetGroupName = subnetGroup.Name,
                DeletionProtection = true,
                SkipFinalSnapshot = true,
                ApplyImmediately = true,
                MultiAz = false,
                PubliclyAccessible = true
            });
        }
    }
}
