using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    public class PatrimonialQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Activo> Activo([Service] NestDbContext nestDbContext) => nestDbContext.Activo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UbicacionActivo> UbicacionActivo([Service] NestDbContext nestDbContext) => nestDbContext.UbicacionActivo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UbicacionTecnica> UbicacionTecnica([Service] NestDbContext nestDbContext) => nestDbContext.UbicacionTecnica;
    }
}
