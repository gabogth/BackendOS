using AutoMapper;
using nest.core.dominio.RRHH.CargoEntities;
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
            CreateMap<HorarioCabeceraCrearDto, HorarioCabecera>();
            CreateMap<HorarioDetalleCrearDto, HorarioDetalle>()
                .ForMember(dest => dest.HorarioDetalleEventos, opt => opt.Ignore());
            CreateMap<HorarioDetalleEventoCrearDto, HorarioDetalleEvento>();
            CreateMap<PersonalCrearDto, Personal>();
            CreateMap<PersonalEstadoCrearDto, PersonalEstado>();
            CreateMap<RegistroAsistenciaCrearDto, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaPoliticaCrearDto, RegistroAsistenciaPolitica>();
        }
    }
}
