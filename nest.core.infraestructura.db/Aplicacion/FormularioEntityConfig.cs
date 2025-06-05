using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.infraestructura.db.Aplicacion
{
    public class FormularioEntityConfig : IEntityTypeConfiguration<Formulario>
    {
        public static readonly string SCHEMA = "aplicacion";
        public static readonly string TABLE = "formulario";
        public void Configure(EntityTypeBuilder<Formulario> builder)
        {
            builder.ToTable(TABLE, SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasValueGenerator<FormularioValueGenerator>();
            builder.Property(x => x.NombreCorto)
                .HasMaxLength(9);
            builder.Property(x => x.Descripcion)
                .HasMaxLength(-1);
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasIndex(x => x.ClaimType).IsUnique();
            builder.HasOne(ic => ic.Modulo)
                .WithMany()
                .HasForeignKey(ic => ic.ModuloId);
            builder.HasData(ObtenerInformacionInicial());
        }

        public List<Formulario> ObtenerInformacionInicial()
        {
            List<Formulario> roles = new List<Formulario>()
            {
                new Formulario { Id = 1, ModuloId = 1, ParentId = null, Orden = 1, ClaimType = "aplicacion-home", Nombre = "Inicio", NombreCorto = "INICIO", Descripcion = "", Controlador = "Seguridad", Action = "Index", Estado = true, Icono = "home" },
                new Formulario { Id = 2, ModuloId = 1, ParentId = null, Orden = 2, ClaimType = null, Nombre = "Aplicacion", NombreCorto = "APLICACIO", Descripcion = "", Controlador = "", Action = "", Estado = true, Icono = "window-restore" },
                new Formulario { Id = 3, ModuloId = 1, ParentId = 2, Orden = 2, ClaimType = "aplicacion-formulario", Nombre = "Formulario", NombreCorto = "FORMULARI", Descripcion = "", Controlador = "Seguridad", Action = "Formulario", Estado = true, Icono = "table-list" },
                new Formulario { Id = 4, ModuloId = 1, ParentId = null, Orden = 3, ClaimType = null, Nombre = "Seguridad", NombreCorto = "SEGURIDAD", Descripcion = "", Controlador = "", Action = "", Estado = true, Icono = "shield" },
                new Formulario { Id = 5, ModuloId = 1, ParentId = 4, Orden = 1, ClaimType = "seguridad-rol", Nombre = "Rol", NombreCorto = "ROL", Descripcion = "", Controlador = "Seguridad", Action = "Rol", Estado = true, Icono = "users" },
                new Formulario { Id = 6, ModuloId = 1, ParentId = 4, Orden = 2, ClaimType = "seguridad-rol-usuario", Nombre = "Rol Usuarios", NombreCorto = "ROLUSER", Descripcion = "", Controlador = "Seguridad", Action = "RolUsuario", Estado = true, Icono = "users" },
                new Formulario { Id = 7, ModuloId = 1, ParentId = 4, Orden = 3, ClaimType = "seguridad-rol-formulario", Nombre = "Rol Formularios", NombreCorto = "ROLFORM", Descripcion = "", Controlador = "Seguridad", Action = "RolFormulario", Estado = true, Icono = "users" },
                new Formulario { Id = 8, ModuloId = 1, ParentId = 4, Orden = 4, ClaimType = "seguridad-usuario", Nombre = "Usuarios", NombreCorto = "USER", Descripcion = "", Controlador = "Seguridad", Action = "Usuario", Estado = true, Icono = "users" },
            };
            return roles;
        }
    }
    public class FormularioValueGenerator : ValueGenerator<long>
    {
        public override bool GeneratesTemporaryValues => false;
        public override long Next(EntityEntry entry) => GeneradorCorrelativo.GetValue(entry.Context, FormularioEntityConfig.SCHEMA, FormularioEntityConfig.TABLE);
        public override async ValueTask<long> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default) => await GeneradorCorrelativo.GetValueAsync(entry.Context, FormularioEntityConfig.SCHEMA, FormularioEntityConfig.TABLE, cancellationToken);
    }
}
