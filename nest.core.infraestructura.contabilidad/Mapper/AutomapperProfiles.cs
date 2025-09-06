using AutoMapper;
using nest.core.dominio.Contabilidad.CuentaContableEntities;
using nest.core.dominio.Contabilidad.CuentaContableTipoEntities;

namespace nest.core.infraestructura.contabilidad.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CuentaContableCrearDto, CuentaContable>();
            CreateMap<CuentaContableTipoCrearDto, CuentaContableTipo>();
        }
    }
}
