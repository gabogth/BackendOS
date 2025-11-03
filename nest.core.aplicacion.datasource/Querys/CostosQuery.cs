using nest.core.dominio.Costos.CentroDeCostosEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CostosQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<CentroDeCostos> CentroDeCostos([Service] NestDbContext nestDbContext) => nestDbContext.CentroDeCostos;
    }
}
