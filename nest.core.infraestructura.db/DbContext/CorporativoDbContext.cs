using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<EstructuraOrganizacional> EstructuraOrganizacional { get; set; }
        public DbSet<EstructuraOrganizacionalTipo> EstructuraOrganizacionalTipo { get; set; }
    }
}
