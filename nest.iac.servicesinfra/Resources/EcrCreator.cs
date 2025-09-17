using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Awsx = Pulumi.Awsx;

namespace nest.iac.servicesinfra.Resources
{
    public class EcrCreator
    {
        private readonly string repositoryName;
        public EcrCreator(string repositoryName)
        {
            this.repositoryName = repositoryName;
        }
        public Awsx.Ecr.Repository Build()
        {
            Awsx.Ecr.Repository repo = Create(this.repositoryName);
            return repo;
        }
        private Awsx.Ecr.Repository Create(string name)
        {
            return new Awsx.Ecr.Repository(name, new Awsx.Ecr.RepositoryArgs
            {
                Name = name,
                ImageScanningConfiguration = new Pulumi.Aws.Ecr.Inputs.RepositoryImageScanningConfigurationArgs
                {
                    ScanOnPush = true,
                },
                ForceDelete = true,
                LifecyclePolicy = new Awsx.Ecr.Inputs.LifecyclePolicyArgs { 
                    Rules = new Pulumi.InputList<Awsx.Ecr.Inputs.LifecyclePolicyRuleArgs> { 
                        new Awsx.Ecr.Inputs.LifecyclePolicyRuleArgs { 
                            MaximumAgeLimit = 30
                        }
                    }
                }
            });
        }
    }
}
