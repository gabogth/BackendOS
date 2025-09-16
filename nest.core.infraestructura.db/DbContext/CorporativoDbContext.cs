using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<EstructuraOrganizacional> EstructuraOrganizacional { get; set; }
        public DbSet<EstructuraOrganizacionalTipo> EstructuraOrganizacionalTipo { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public void OnModelCreatingCorporativo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstructuraOrganizacional>().HasQueryFilter(x => x.EmpresaId == this.EmpresaId);
        }
    }
}
