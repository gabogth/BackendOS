using AutoMapper;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Security;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.infraestructura.security.Mapper
{
    public class AutomapperProfiles: Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ModuloCrearDto, Modulo>();
            CreateMap<FormularioCrearDto, Formulario>();
            CreateMap<ApplicationRoleDto, ApplicationRole>();
            CreateMap<UsuarioEmpresaCrearDto, UsuarioEmpresa>();
        }
    }
}
