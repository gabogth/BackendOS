using AutoMapper;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;
using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;

namespace nest.core.infraestructura.finanzas.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<CuentaCorrienteCrearDto, CuentaCorriente>();
            CreateMap<EntidadFinancieraCrearDto, EntidadFinanciera>();
            CreateMap<MonedaCrearDto, Moneda>();
            CreateMap<OrigenFinancieroCrearDto, OrigenFinanciero>();
            CreateMap<PuntoFinancieroCrearDto, PuntoFinanciero>();
            CreateMap<TerceroCrearDto, Tercero>();
            CreateMap<FinancieroCabeceraCrearDto, FinancieroCabecera>();
            CreateMap<FinancieroDetalleCrearDto, FinancieroDetalle>();
        }
    }
}
