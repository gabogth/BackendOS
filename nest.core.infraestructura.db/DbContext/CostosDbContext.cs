using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Costos.CentroDeCostosEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<CentroDeCostos> CentroDeCostos { get; set; }
    }
}
