using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Aplicacion.Modulo;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<Modulo> Modulo { get; set; }
        public DbSet<Formulario> Formulario { get; set; }

    }
}
