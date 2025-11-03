using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CorporativoQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Empresa> Empresa([Service] NestDbContext nestDbContext) => nestDbContext.Empresa;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<EstructuraOrganizacional> EstructuraOrganizacional([Service] NestDbContext nestDbContext) => nestDbContext.EstructuraOrganizacional;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<EstructuraOrganizacionalTipo> EstructuraOrganizacionalTipo([Service] NestDbContext nestDbContext) => nestDbContext.EstructuraOrganizacionalTipo;
    }
}
