using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<Activo> Activo { get; set; }
        public DbSet<UbicacionActivo> UbicacionActivo { get; set; }
        public DbSet<UbicacionTecnica> UbicacionTecnica { get; set; }
    }
}
