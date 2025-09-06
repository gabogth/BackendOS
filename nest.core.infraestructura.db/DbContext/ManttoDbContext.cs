using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.infraestructura.db.DbContext
{
    public partial class NestDbContext
    {
        public DbSet<Labor> Labor { get; set; }
        public DbSet<MantenimientoTipo> MantenimientoTipo { get; set; }
        public DbSet<OrdenServicioCabecera> OrdenServicioCabecera { get; set; }
        public DbSet<OrdenServicioMantenimientoExterno> OrdenServicioMantenimientoExterno { get; set; }
        public DbSet<OrdenServicioTipo> OrdenServicioTipo { get; set; }
        public DbSet<OrdenTrabajoCabecera> OrdenTrabajoCabecera { get; set; }
        public DbSet<OrdenTrabajoDetalle> OrdenTrabajoDetalle { get; set; }
        public DbSet<OrdenTrabajoDetalleActivo> OrdenTrabajoDetalleActivo { get; set; }
        public DbSet<OrdenTrabajoPersonal> OrdenTrabajoPersonal { get; set; }
    }
}
