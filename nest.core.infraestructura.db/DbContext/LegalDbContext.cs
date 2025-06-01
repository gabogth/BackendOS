using Microsoft.EntityFrameworkCore;
using nest.core.dominio.General;
using nest.core.dominio.Legal;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<ContratoCabecera> ContratoCabecera { get; set; }
        public DbSet<ContratoDetalle> ContratoDetalle { get; set; }
        public DbSet<ContratoPersonal> ContratoPersonal { get; set; }
        public DbSet<ContratoTipo> ContratoTipo { get; set; }

    }
}
