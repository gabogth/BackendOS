using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    public class ManttoQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Labor> Labor([Service] NestDbContext nestDbContext) => nestDbContext.Labor;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<MantenimientoTipo> MantenimientoTipo([Service] NestDbContext nestDbContext) => nestDbContext.MantenimientoTipo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrdenServicioCabecera> OrdenServicioCabecera([Service] NestDbContext nestDbContext) => nestDbContext.OrdenServicioCabecera;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrdenServicioMantenimientoExterno> OrdenServicioMantenimientoExterno([Service] NestDbContext nestDbContext) => nestDbContext.OrdenServicioMantenimientoExterno;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrdenServicioTipo> OrdenServicioTipo([Service] NestDbContext nestDbContext) => nestDbContext.OrdenServicioTipo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrdenTrabajoCabecera> OrdenTrabajoCabecera([Service] NestDbContext nestDbContext) => nestDbContext.OrdenTrabajoCabecera;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrdenTrabajoDetalle> OrdenTrabajoDetalle([Service] NestDbContext nestDbContext) => nestDbContext.OrdenTrabajoDetalle;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrdenTrabajoDetalleActivo> OrdenTrabajoDetalleActivo([Service] NestDbContext nestDbContext) => nestDbContext.OrdenTrabajoDetalleActivo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrdenTrabajoPersonal> OrdenTrabajoPersonal([Service] NestDbContext nestDbContext) => nestDbContext.OrdenTrabajoPersonal;
    }
}
