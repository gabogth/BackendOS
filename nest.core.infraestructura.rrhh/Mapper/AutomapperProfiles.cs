using AutoMapper;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.GrupoHorarioEntities;

namespace nest.core.infraestructura.rrhh.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CargoCrearDto, Cargo>();
            CreateMap<GrupoHorarioCrearDto, GrupoHorario>();
        }
    }
}
