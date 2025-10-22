using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aws = Pulumi.Aws;

namespace nest.iac.generalinfra.Resources
{
    public class BucketCreator
    {
        private readonly string bucketName;
        public BucketCreator(string bucketName)
        {
            this.bucketName = bucketName;
        }

        public Aws.S3.Bucket Build()
        {
            return CreateBucket();
        }

        private Aws.S3.Bucket CreateBucket()
        {
            return new Aws.S3.Bucket(this.bucketName, new Aws.S3.BucketArgs
            {
                BucketName = this.bucketName,
                Acl = "private",
                ForceDestroy = false,
                Versioning = new Aws.S3.Inputs.BucketVersioningArgs
                {
                    Enabled = false
                }
            });
        }
    }
}
