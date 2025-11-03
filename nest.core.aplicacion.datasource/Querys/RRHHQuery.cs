using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using nest.core.infraestructura.db.DbContext;
using System;

namespace nest.core.aplicacion.datasource.Querys
{
    public class RRHHQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Cargo> Cargos([Service] NestDbContext nestDbContext) => nestDbContext.Cargos;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<GrupoTrabajo> GrupoTrabajo([Service] NestDbContext nestDbContext) => nestDbContext.GrupoTrabajo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<GrupoTrabajoPersona> GrupoTrabajoPersona([Service] NestDbContext nestDbContext) => nestDbContext.GrupoTrabajoPersona;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<HorarioCabecera> HorarioCabeceras([Service] NestDbContext nestDbContext) => nestDbContext.HorarioCabeceras;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<HorarioDetalle> HorarioDetalles([Service] NestDbContext nestDbContext) => nestDbContext.HorarioDetalles;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<HorarioDetalleEvento> HorarioDetalleEventos([Service] NestDbContext nestDbContext) => nestDbContext.HorarioDetalleEventos;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Personal> Personales([Service] NestDbContext nestDbContext) => nestDbContext.Personales;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PersonalEstado> PersonalEstado([Service] NestDbContext nestDbContext) => nestDbContext.PersonalEstado;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RegistroAsistencia> RegistroAsistencia([Service] NestDbContext nestDbContext) => nestDbContext.RegistroAsistencia;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RegistroAsistenciaPolitica> RegistroAsistenciaPolitica([Service] NestDbContext nestDbContext) => nestDbContext.RegistroAsistenciaPolitica;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RegistroAsistenciaOrdenTrabajo> RegistroAsistenciaOrdenTrabajo([Service] NestDbContext nestDbContext) => nestDbContext.RegistroAsistenciaOrdenTrabajo;

        [UsePaging(IncludeTotalCount = true)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RegistroAsistenciaAdjunto> RegistroAsistenciaAdjunto([Service] NestDbContext nestDbContext) => nestDbContext.RegistroAsistenciaAdjunto;
    }
}
