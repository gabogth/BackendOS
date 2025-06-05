using AutoMapper;
using nest.core.dominio.Corporativo;

namespace nest.core.infraestructura.corporativo.Mapper;

public class AutomapperProfiles : Profile
{
    public AutomapperProfiles()
    {
        CreateMap<EstructuraOrganizacionalTipoCrearDto, EstructuraOrganizacionalTipo>();
    }
}
