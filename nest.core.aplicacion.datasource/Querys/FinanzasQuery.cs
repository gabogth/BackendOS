using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.dominio.Finanzas.FinancieroLogisticaEntities;
using nest.core.dominio.Finanzas.FinancieroOrdenServicioEntities;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class FinanzasQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<CuentaCorriente> CuentaCorriente([Service] NestDbContext nestDbContext) => nestDbContext.CuentaCorriente;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<EntidadFinanciera> EntidadFinanciera([Service] NestDbContext nestDbContext) => nestDbContext.EntidadFinanciera;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FinancieroCabecera> FinancieroCabecera([Service] NestDbContext nestDbContext) => nestDbContext.FinancieroCabecera;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FinancieroDetalle> FinancieroDetalle([Service] NestDbContext nestDbContext) => nestDbContext.FinancieroDetalle;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FinancieroLogistica> FinancieroLogistica([Service] NestDbContext nestDbContext) => nestDbContext.FinancieroLogistica;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FinancieroOrdenServicio> FinancieroOrdenServicio([Service] NestDbContext nestDbContext) => nestDbContext.FinancieroOrdenServicio;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Moneda> Moneda([Service] NestDbContext nestDbContext) => nestDbContext.Moneda;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrigenFinanciero> OrigenFinanciero([Service] NestDbContext nestDbContext) => nestDbContext.OrigenFinanciero;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PuntoFinanciero> PuntoFinanciero([Service] NestDbContext nestDbContext) => nestDbContext.PuntoFinanciero;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Tercero> Tercero([Service] NestDbContext nestDbContext) => nestDbContext.Tercero;
    }
}
