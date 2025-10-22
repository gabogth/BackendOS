namespace nest.core.infraestructura.general.Storage
{
    public class AmazonS3StorageOptions
    {
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Region { get; set; }
        public string ServiceURL { get; set; }
        public bool ForcePathStyle { get; set; }
        public string DefaultBucketName { get; set; }
    }
}
