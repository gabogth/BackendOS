using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<CuentaContable> CuentaContable { get; set; }
        public DbSet<CuentaContableTipo> CuentaContableTipo { get; set; }
    }
}
