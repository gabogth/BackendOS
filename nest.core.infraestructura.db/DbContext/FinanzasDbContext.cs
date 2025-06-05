using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<Moneda> Moneda { get; set; }
    }
}
