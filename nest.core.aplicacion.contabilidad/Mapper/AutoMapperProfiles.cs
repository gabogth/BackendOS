using AutoMapper;
using nest.core.aplicacion.contabilidad.CuentaContableTipos.Commands;
using nest.core.aplicacion.contabilidad.CuentaContables.Commands;
using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.aplicacion.contabilidad.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CuentaContableTipoCrearCommand, CuentaContableTipo>();
            CreateMap<CuentaContableTipoModificarCommand, CuentaContableTipo>();
            CreateMap<CuentaContableCrearCommand, CuentaContable>();
            CreateMap<CuentaContableModificarCommand, CuentaContable>();
        }
    }
}
