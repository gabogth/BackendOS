using AutoMapper;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;

namespace nest.core.infraestructura.corporativo.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<EstructuraOrganizacionalTipoCrearDto, EstructuraOrganizacionalTipo>();
            CreateMap<EstructuraOrganizacionalCrearDto, EstructuraOrganizacional>();
        }
    }
}
