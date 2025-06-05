using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.infraestructura.db.General
{
    public class SexoEntityConfig : IEntityTypeConfiguration<Sexo>
    {
        public static readonly string SCHEMA = "dbo";
        public static readonly string TABLE = "sexo";
        public void Configure(EntityTypeBuilder<Sexo> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<GenericValueGenerator<byte>>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<Sexo> ObtenerInformacionInicial()
        {
            List<Sexo> entidades = new List<Sexo>()
            {
                new Sexo { Id = 1, Nombre = "Masculino", NombreCorto = "M" },
                new Sexo { Id = 2, Nombre = "Femenino", NombreCorto = "F" },
            };
            return entidades;
        }
    }
}
