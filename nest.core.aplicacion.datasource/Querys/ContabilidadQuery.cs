using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    public class ContabilidadQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<CuentaContable> CuentaContable([Service] NestDbContext nestDbContext) => nestDbContext.CuentaContable;
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<CuentaContableTipo> CuentaContableTipo([Service] NestDbContext nestDbContext) => nestDbContext.CuentaContableTipo;
    }
}
