using AutoMapper;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.PersonalEstadoEntities;

namespace nest.core.infraestructura.rrhh.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CargoCrearDto, Cargo>();
            CreateMap<GrupoHorarioCrearDto, GrupoHorario>();
            CreateMap<HorarioCabeceraCrearDto, HorarioCabecera>();
            CreateMap<HorarioDetalleCrearDto, HorarioDetalle>();
            CreateMap<PersonalCrearDto, Personal>();
            CreateMap<PersonalEstadoCrearDto, PersonalEstado>();
        }
    }
}
