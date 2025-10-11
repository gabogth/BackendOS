using AutoMapper;
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

namespace nest.core.infraestructura.rrhh.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CargoCrearDto, Cargo>();
            CreateMap<GrupoTrabajoCrearDto, GrupoTrabajo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoTrabajoPersonas, opt => opt.Ignore());
            CreateMap<HorarioCabeceraCrearDto, HorarioCabecera>();
            CreateMap<HorarioDetalleCrearDto, HorarioDetalle>()
                .ForMember(dest => dest.HorarioDetalleEventos, opt => opt.Ignore());
            CreateMap<HorarioDetalleEventoCrearDto, HorarioDetalleEvento>();
            CreateMap<PersonalCrearDto, Personal>();
            CreateMap<PersonalEstadoCrearDto, PersonalEstado>();
            CreateMap<RegistroAsistenciaCrearDto, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaPoliticaCrearDto, RegistroAsistenciaPolitica>();
            CreateMap<GrupoTrabajoPersonaCrearDto, GrupoTrabajoPersona>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoTrabajo, opt => opt.Ignore());
        }
    }
}
