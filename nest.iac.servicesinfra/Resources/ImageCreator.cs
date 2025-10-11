using Awsx = Pulumi.Awsx;

namespace nest.iac.servicesinfra.Resources
{
    public class ImageCreator
    {
        private readonly string name;
        private readonly Awsx.Ecr.Repository repository;
        private readonly string contextPath;
        private readonly string dockerFile;
        private readonly string versionImage;

        public ImageCreator(string name, Awsx.Ecr.Repository repository, string contextPath, string dockerFile, string versionImage)
        {
            this.name = name;
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.contextPath = string.IsNullOrEmpty(contextPath) ? "." : contextPath;
            this.dockerFile = string.IsNullOrEmpty(dockerFile) ? "Dockerfile" : dockerFile;
            this.versionImage = versionImage; // si quieres usar un tag dado como fallback
        }

        public Awsx.Ecr.Image? Build()
        {
            return new Awsx.Ecr.Image(this.name, new Awsx.Ecr.ImageArgs
            {
                ImageName = this.name,
                RepositoryUrl = this.repository.Url,
                Context = this.contextPath,
                Dockerfile = this.dockerFile,
                ImageTag = this.versionImage
            });
        }

    }
}