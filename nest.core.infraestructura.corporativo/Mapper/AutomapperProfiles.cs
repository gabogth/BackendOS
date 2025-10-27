using AutoMapper;
using nest.core.aplicacion.corporativo.Empresas.Commands;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;
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
            CreateMap<EstructuraOrganizacionalTipoCrearCommand, EstructuraOrganizacionalTipo>();
            CreateMap<EstructuraOrganizacionalTipoModificarCommand, EstructuraOrganizacionalTipo>();
            CreateMap<EstructuraOrganizacionalCrearCommand, EstructuraOrganizacional>();
            CreateMap<EstructuraOrganizacionalModificarCommand, EstructuraOrganizacional>();
            CreateMap<EmpresaCrearCommand, Empresa>();
            CreateMap<EmpresaModificarCommand, Empresa>();
        }
    }
}
