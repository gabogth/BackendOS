using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    public class AplicacionQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Modulo> Modulo([Service] NestDbContext nestDbContext) => nestDbContext.Modulo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Formulario> Formulario([Service] NestDbContext nestDbContext) => nestDbContext.Formulario;
    }
}
