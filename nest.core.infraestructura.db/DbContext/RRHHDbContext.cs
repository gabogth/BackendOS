using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<ContratoTipo> ContratoTipo { get; set; }
        public DbSet<LicenciaConducir> LicenciaConducir { get; set; }
    }
}
