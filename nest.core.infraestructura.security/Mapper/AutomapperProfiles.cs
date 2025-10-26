using AutoMapper;
using nest.core.aplicacion.security.Formularios.Commands;
using nest.core.aplicacion.security.Modulos.Commands;
using nest.core.dominio.Aplicacion.Formulario;
using nest.core.dominio.Aplicacion.Modulo;
using nest.core.dominio.Security.UsuarioEmpresa;

namespace nest.core.infraestructura.security.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ModuloCrearCommand, Modulo>();
            CreateMap<ModuloModificarCommand, Modulo>();
            CreateMap<FormularioCrearCommand, Formulario>();
            CreateMap<FormularioModificarCommand, Formulario>();
            CreateMap<UsuarioEmpresaCrearDto, UsuarioEmpresa>();
        }
    }
}
