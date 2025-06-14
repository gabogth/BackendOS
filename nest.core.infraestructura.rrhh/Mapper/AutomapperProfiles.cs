using AutoMapper;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoHorarioEntities;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.infraestructura.rrhh.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CargoCrearDto, Cargo>();
            CreateMap<GrupoHorarioCrearDto, GrupoHorario>();
            CreateMap<PersonalCrearDto, Personal>();
        }
    }
}
