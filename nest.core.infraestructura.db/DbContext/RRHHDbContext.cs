using Microsoft.EntityFrameworkCore;
using nest.core.dominio.RRHH;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<GrupoHorario> GrupoHorario { get; set; }
        public DbSet<HorarioCabecera> HorarioCabecera { get; set; }
        public DbSet<HorarioDetalle> HorarioDetalle { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<PersonalConfiguracion> PersonalConfiguracion { get; set; }
        public DbSet<Sexo> Sexo { get; set; }
    }
}
