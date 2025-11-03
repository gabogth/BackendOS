using nest.core.dominio.Legal.ContratoCabeceraEntities;
using nest.core.dominio.Legal.ContratoDetalleEntities;
using nest.core.dominio.Legal.ContratoPersonalEntities;
using nest.core.dominio.Legal.ContratoTipoEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    public class LegalQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContratoCabecera> ContratoCabecera([Service] NestDbContext nestDbContext) => nestDbContext.ContratoCabecera;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContratoDetalle> ContratoDetalle([Service] NestDbContext nestDbContext) => nestDbContext.ContratoDetalle;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContratoPersonal> ContratoPersonal([Service] NestDbContext nestDbContext) => nestDbContext.ContratoPersonal;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContratoTipo> ContratoTipo([Service] NestDbContext nestDbContext) => nestDbContext.ContratoTipo;
    }
}
