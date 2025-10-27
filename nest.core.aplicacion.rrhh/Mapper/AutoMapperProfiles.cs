using AutoMapper;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;
using nest.core.aplicacion.rrhh.Horarios.Commands;
using nest.core.aplicacion.rrhh.Personales.Commands;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CargoCrearCommand, Cargo>();
            CreateMap<CargoModificarCommand, Cargo>();
            CreateMap<HorarioCrearCommand, HorarioCabecera>();
            CreateMap<HorarioModificarCommand, HorarioCabecera>();
            CreateMap<PersonalCrearCommand, Personal>();
            CreateMap<PersonalModificarCommand, Personal>();
            CreateMap<HorarioDetalleEventoCrearCommand, HorarioDetalleEvento>();
            CreateMap<HorarioDetalleEventoModificarCommand, HorarioDetalleEvento>();
            CreateMap<HorarioDetalleCrearCommand, HorarioDetalle>();
            CreateMap<HorarioDetalleModificarCommand, HorarioDetalle>();
            CreateMap<GrupoTrabajoCrearCommand, GrupoTrabajo>();
            CreateMap<GrupoTrabajoModificarCommand, GrupoTrabajo>();
            CreateMap<GrupoTrabajoPersonaCrearCommand, GrupoTrabajoPersona>();
            CreateMap<GrupoTrabajoPersonaModificarCommand, GrupoTrabajoPersona>();
            CreateMap<PersonalEstadoCrearCommand, PersonalEstado>();
            CreateMap<PersonalEstadoModificarCommand, PersonalEstado>();
            CreateMap<RegistroAsistenciaCrearCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaCrearUsuarioActualCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaModificarCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaOrdenTrabajoCrearCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaOrdenTrabajoCrearUsuarioActualCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaOrdenTrabajoModificarCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaPoliticaCrearCommand, RegistroAsistenciaPolitica>();
            CreateMap<RegistroAsistenciaPoliticaModificarCommand, RegistroAsistenciaPolitica>();
        }
    }
}
