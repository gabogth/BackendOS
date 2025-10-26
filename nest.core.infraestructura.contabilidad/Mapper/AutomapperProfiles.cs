using AutoMapper;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;
using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.infraestructura.contabilidad.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CuentaContableCrearCommand, CuentaContable>();
            CreateMap<CuentaContableModificarCommand, CuentaContable>();
            CreateMap<CuentaContableTipoCrearCommand, CuentaContableTipo>();
            CreateMap<CuentaContableTipoModificarCommand, CuentaContableTipo>();
        }
    }
}
