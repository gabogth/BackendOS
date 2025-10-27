using AutoMapper;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;
using nest.core.aplicacion.rrhh.Horarios.Commands;
using nest.core.aplicacion.rrhh.Personales.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.infraestructura.rrhh.Mapper;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        CreateMap<CargoCrearCommand, Cargo>();
        CreateMap<CargoModificarCommand, Cargo>();
        CreateMap<GrupoTrabajoCrearCommand, GrupoTrabajo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.GrupoTrabajoPersonas, opt => opt.Ignore());
        CreateMap<GrupoTrabajoModificarCommand, GrupoTrabajo>()
            .ForMember(dest => dest.GrupoTrabajoPersonas, opt => opt.Ignore());
        CreateMap<HorarioCrearCommand, HorarioCabecera>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<HorarioModificarCommand, HorarioCabecera>();
        CreateMap<HorarioDetalleCrearCommand, HorarioDetalle>();
        CreateMap<HorarioDetalleModificarCommand, HorarioDetalle>();
        CreateMap<HorarioDetalleEventoCrearCommand, HorarioDetalleEvento>();
        CreateMap<HorarioDetalleEventoModificarCommand, HorarioDetalleEvento>();
        CreateMap<PersonalCrearCommand, Personal>();
        CreateMap<PersonalModificarCommand, Personal>();
        CreateMap<PersonalEstadoCrearCommand, PersonalEstado>();
        CreateMap<PersonalEstadoModificarCommand, PersonalEstado>();
        CreateMap<RegistroAsistenciaCrearCommand, RegistroAsistencia>();
        CreateMap<RegistroAsistenciaModificarCommand, RegistroAsistencia>();
        CreateMap<RegistroAsistenciaCrearUsuarioActualCommand, RegistroAsistencia>();
        CreateMap<RegistroAsistenciaOrdenTrabajoCrearCommand, RegistroAsistencia>();
        CreateMap<RegistroAsistenciaOrdenTrabajoCrearUsuarioActualCommand, RegistroAsistencia>();
        CreateMap<RegistroAsistenciaOrdenTrabajoModificarCommand, RegistroAsistencia>();
        CreateMap<RegistroAsistenciaPoliticaCrearCommand, RegistroAsistenciaPolitica>();
        CreateMap<RegistroAsistenciaPoliticaModificarCommand, RegistroAsistenciaPolitica>();
        CreateMap<GrupoTrabajoPersonaCrearCommand, GrupoTrabajoPersona>();
        CreateMap<GrupoTrabajoPersonaModificarCommand, GrupoTrabajoPersona>();
        CreateMap<GrupoTrabajoPersonaCommand, GrupoTrabajoPersona>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.GrupoTrabajo, opt => opt.Ignore());
    }
}
