using AutoMapper;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;
using nest.core.aplicacion.rrhh.Personales.Commands;
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
        CreateMap<GrupoTrabajoCrearDto, GrupoTrabajo>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.GrupoTrabajoPersonas, opt => opt.Ignore());
        CreateMap<HorarioCabeceraCrearDto, HorarioCabecera>();
        CreateMap<HorarioDetalleCrearCommand, HorarioDetalle>();
        CreateMap<HorarioDetalleModificarCommand, HorarioDetalle>();
        CreateMap<HorarioDetalleCrearDto, HorarioDetalle>()
            .ForMember(dest => dest.HorarioDetalleEventos, opt => opt.Ignore());
        CreateMap<HorarioDetalleEventoCrearCommand, HorarioDetalleEvento>();
        CreateMap<HorarioDetalleEventoModificarCommand, HorarioDetalleEvento>();
        CreateMap<HorarioDetalleEventoCrearDto, HorarioDetalleEvento>();
        CreateMap<PersonalCrearCommand, Personal>();
        CreateMap<PersonalModificarCommand, Personal>();
        CreateMap<PersonalEstadoCrearCommand, PersonalEstado>();
        CreateMap<PersonalEstadoModificarCommand, PersonalEstado>();
        CreateMap<RegistroAsistenciaCrearDto, RegistroAsistencia>();
        CreateMap<RegistroAsistenciaOrdenTrabajoCrearDto, RegistroAsistenciaOrdenTrabajo>()
            .ForMember(dest => dest.RegistroAsistencia, opt => opt.Ignore())
            .ForMember(dest => dest.OrdenTrabajoCabecera, opt => opt.Ignore());
        CreateMap<RegistroAsistenciaPoliticaCrearDto, RegistroAsistenciaPolitica>();
        CreateMap<GrupoTrabajoPersonaCrearCommand, GrupoTrabajoPersona>();
        CreateMap<GrupoTrabajoPersonaModificarCommand, GrupoTrabajoPersona>();
        CreateMap<GrupoTrabajoPersonaCrearDto, GrupoTrabajoPersona>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.GrupoTrabajo, opt => opt.Ignore());
    }
}
