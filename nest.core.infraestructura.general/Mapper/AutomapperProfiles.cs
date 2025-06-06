using AutoMapper;
using nest.core.dominio.General.PersonaEntities;

namespace nest.core.infraestructura.general.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<PersonaCrearDto, Persona>();
        }
    }
}
