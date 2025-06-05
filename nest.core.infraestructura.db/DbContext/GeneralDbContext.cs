using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<DocumentoTipo> DocumentoTipo { get; set; }
        public DbSet<DocumentoIdentidadTipo> DocumentoIdentidadTipo { get; set; }
        public DbSet<LicenciaConducir> LicenciaConducir { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<Persona> Persona { get; set; }

    }
}
