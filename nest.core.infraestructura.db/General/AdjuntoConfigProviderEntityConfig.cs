using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.db.General
{
    public class AdjuntoConfigProviderEntityConfig : IEntityTypeConfiguration<AdjuntoConfigProvider>
    {
        public void Configure(EntityTypeBuilder<AdjuntoConfigProvider> builder)
        {
            builder.ToTable("adjunto_config", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<AdjuntoConfigProviderValueGenerator>();
            builder.HasData(GetData());
        }

        private List<AdjuntoConfigProvider> GetData()
        {
            return new List<AdjuntoConfigProvider>
            {
                new AdjuntoConfigProvider { Id = AdjuntoConfigProviderModuloEnum.PersonalFoto, Nombre = "USUARIOS_FOTOS_REPO", AdjuntoProvider = AdjuntoProviderEnum.AmazonS3, Container = "Container", NombreCorto = "USRFOTBKT", MainPath = "/usuarios/fotos" },
            };
        }
    }
    public class AdjuntoConfigProviderValueGenerator : ValueGenerator<int>
    {
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry) => GeneradorCorrelativo.GetValue<int>(entry, object () => ((NestDbContext)entry.Context).AdjuntoConfigProvider.Max(x => x.Id));
        public override async ValueTask<int> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync<int>(entry, object () => ((NestDbContext)entry.Context).AdjuntoConfigProvider.Max(x => x.Id), cancellationToken);
    }
}
