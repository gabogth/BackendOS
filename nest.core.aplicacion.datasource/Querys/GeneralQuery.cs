using nest.core.dominio.General.AdjuntoEntities;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.dominio.General.DepartamentoEntites;
using nest.core.dominio.General.DistritoEntities;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;
using nest.core.dominio.General.DocumentoTipoEntities;
using nest.core.dominio.General.LicenciaConducirEntities;
using nest.core.dominio.General.PaisEntities;
using nest.core.dominio.General.PersonaAdjuntoEntities;
using nest.core.dominio.General.PersonaEntities;
using nest.core.dominio.General.ProvinciaEntities;
using nest.core.dominio.General.SexoEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    public class GeneralQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<DocumentoTipo> DocumentoTipo([Service] NestDbContext nestDbContext) => nestDbContext.DocumentoTipo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<DocumentoIdentidadTipo> DocumentoIdentidadTipo([Service] NestDbContext nestDbContext) => nestDbContext.DocumentoIdentidadTipo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<LicenciaConducir> LicenciaConducir([Service] NestDbContext nestDbContext) => nestDbContext.LicenciaConducir;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Pais> Pais([Service] NestDbContext nestDbContext) => nestDbContext.Pais;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Departamento> Departamento([Service] NestDbContext nestDbContext) => nestDbContext.Departamento;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Provincia> Provincia([Service] NestDbContext nestDbContext) => nestDbContext.Provincia;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Distrito> Distrito([Service] NestDbContext nestDbContext) => nestDbContext.Distrito;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Persona> Persona([Service] NestDbContext nestDbContext) => nestDbContext.Persona;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Sexo> Sexos([Service] NestDbContext nestDbContext) => nestDbContext.Sexos;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AdjuntoConfigProvider> AdjuntoConfigProvider([Service] NestDbContext nestDbContext) => nestDbContext.AdjuntoConfigProvider;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Adjunto> Adjunto([Service] NestDbContext nestDbContext) => nestDbContext.Adjunto;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AdjuntoTipo> AdjuntoTipo([Service] NestDbContext nestDbContext) => nestDbContext.AdjuntoTipo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PersonaAdjunto> PersonaAdjunto([Service] NestDbContext nestDbContext) => nestDbContext.PersonaAdjunto;
    }
}
