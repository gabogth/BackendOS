using AutoMapper;
using nest.core.aplicacion.security.Formularios.Commands;
using nest.core.aplicacion.security.Modulos.Commands;
using nest.core.aplicacion.security.Roles.Commands;
using nest.core.aplicacion.security.UsuarioEmpresas.Commands;
using nest.core.aplicacion.security.Usuarios.Commands;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Security;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.aplicacion.security.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RoleCrearCommand, ApplicationRole>();
            CreateMap<RoleModificarCommand, ApplicationRole>();
            CreateMap<FormularioCrearCommand, Formulario>();
            CreateMap<FormularioModificarCommand, Formulario>();
            CreateMap<UsuarioEmpresaCrearCommand, UsuarioEmpresa>();
            CreateMap<UsuarioEmpresaModificarCommand, UsuarioEmpresa>();
            CreateMap<UsuarioCrearCommand, ApplicationUser>();
            CreateMap<UsuarioModificarCommand, ApplicationUser>();
            CreateMap<ModuloCrearCommand, Modulo>();
            CreateMap<ModuloModificarCommand, Modulo>();
        }
    }
}
