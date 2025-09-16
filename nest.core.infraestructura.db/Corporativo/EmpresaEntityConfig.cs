using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.infraestructura.db.Corporativo
{
    public class EmpresaEntityConfig: IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("empresa", "organizacion");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<int>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9)
                .IsRequired();
            builder.HasData(ObtenerInformacionInicial());
        }
        public List<Empresa> ObtenerInformacionInicial()
        {
            return new List<Empresa>()
            {
                new Empresa { Id = 1, Nombre = "Default", NombreCorto = "Def", Estado = true }
            };
        }
    }
}
