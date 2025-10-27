using AutoMapper;
using nest.core.aplicacion.corporativo.Empresas.Commands;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionales.Commands;
using nest.core.aplicacion.corporativo.EstructuraOrganizacionalTipos.Commands;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalEntities;
using nest.core.dominio.Corporativo.EstructuraOrganizacionalTipoEntities;

namespace nest.core.aplicacion.corporativo.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<EmpresaCrearCommand, Empresa>();
            CreateMap<EmpresaModificarCommand, Empresa>();
            CreateMap<EstructuraOrganizacionalCrearCommand, EstructuraOrganizacional>();
            CreateMap<EstructuraOrganizacionalModificarCommand, EstructuraOrganizacional>();
            CreateMap<EstructuraOrganizacionalTipoCrearCommand, EstructuraOrganizacionalTipo>();
            CreateMap<EstructuraOrganizacionalTipoModificarCommand, EstructuraOrganizacionalTipo>();
        }
    }
}
