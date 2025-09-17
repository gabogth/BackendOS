using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }
        public void OnModelCreatingSecurity(ModelBuilder modelBuilder)
        {
            
        }
    }
}
