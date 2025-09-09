using Pulumi;
using Pulumi.Aws.Ecs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Aws = Pulumi.Aws;

namespace nest.iac.generalinfra.Resources
{
    public class EcsCreator
    {
        private readonly string clusterName;
        private readonly string capacityName;
        public EcsCreator(string clusterName, string capacityName)
        {
            this.clusterName = clusterName;
            this.capacityName = capacityName;
        }

        public Aws.Ecs.Cluster Build()
        {
            var cluster = CreateCluster(this.clusterName);
            var capacity = AddCapacity(this.capacityName, cluster);
            return cluster;
        }

        private Aws.Ecs.Cluster CreateCluster(string name)
        {
            return new Aws.Ecs.Cluster(name, new Aws.Ecs.ClusterArgs
            {
                Name = name,
                Settings = new[] {
                    new Aws.Ecs.Inputs.ClusterSettingArgs {
                        Name = "containerInsights",
                        Value = "enabled"
                    }
                }
            });
        }

        private Aws.Ecs.ClusterCapacityProviders AddCapacity(string name, Aws.Ecs.Cluster cluster)
        {
            return new Aws.Ecs.ClusterCapacityProviders(name, new ClusterCapacityProvidersArgs
            {
                ClusterName = cluster.Name,
                CapacityProviders = ["FARGATE"],
                DefaultCapacityProviderStrategies = new[]
                {
                    new Aws.Ecs.Inputs.ClusterCapacityProvidersDefaultCapacityProviderStrategyArgs
                    {
                        Base = 1,
                        Weight = 100,
                        CapacityProvider = "FARGATE"
                    }
                }
            });
        }
    }
}
