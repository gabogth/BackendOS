using AutoMapper;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.infraestructura.corporativo.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<EstructuraOrganizacionalTipoCrearDto, EstructuraOrganizacionalTipo>();
            CreateMap<EstructuraOrganizacionalCrearDto, EstructuraOrganizacional>();
            CreateMap<EmpresaCrearDto, Empresa>();
            CreateMap<UsuarioEmpresaCrearDto, UsuarioEmpresa>();
        }
    }
}
