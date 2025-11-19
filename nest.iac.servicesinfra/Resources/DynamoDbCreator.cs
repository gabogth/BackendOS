using Aws = Pulumi.Aws;

namespace nest.iac.servicesinfra.Resources
{
    public class DynamoDbCreator
    {
        public DynamoDbCreator()
        {
        }

        public Aws.DynamoDB.Table Build(string tableName)
        {
            return new Aws.DynamoDB.Table(tableName, new Aws.DynamoDB.TableArgs
            {
                Name = tableName,
                BillingMode = "PAY_PER_REQUEST",
                HashKey = "serviceName",
                Attributes = {
                    new Aws.DynamoDB.Inputs.TableAttributeArgs
                    {
                        Name = "serviceName",
                        Type = "S"
                    }
                },
            });
        }

    }
}