using nest.core.dominio.Logistica;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.dominio.Logistica.Transaccional;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class LogisticaQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Almacen> Almacen([Service] NestDbContext nestDbContext) => nestDbContext.Almacen;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<LogisticaTransaccion> LogisticaTransaccion([Service] NestDbContext nestDbContext) => nestDbContext.LogisticaTransaccion;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Producto> Producto([Service] NestDbContext nestDbContext) => nestDbContext.Producto;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ProductoLote> ProductoLote([Service] NestDbContext nestDbContext) => nestDbContext.ProductoLote;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UnidadMedida> UnidadMedida([Service] NestDbContext nestDbContext) => nestDbContext.UnidadMedida;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<InventarioCabecera> InventarioCabecera([Service] NestDbContext nestDbContext) => nestDbContext.InventarioCabecera;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<InventarioDetalle> InventarioDetalle([Service] NestDbContext nestDbContext) => nestDbContext.InventarioDetalle;
    }
}
