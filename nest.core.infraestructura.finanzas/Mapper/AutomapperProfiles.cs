using AutoMapper;
using nest.core.aplicacion.finanzas.CuentaCorriente.Commands;
using nest.core.aplicacion.finanzas.EntidadFinanciera.Commands;
using nest.core.aplicacion.finanzas.Financiero.Commands;
using nest.core.aplicacion.finanzas.Moneda.Commands;
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
            CreateMap<CuentaCorrienteCrearCommand, CuentaCorriente>();
            CreateMap<CuentaCorrienteModificarCommand, CuentaCorriente>();
            CreateMap<EntidadFinancieraCrearCommand, EntidadFinanciera>();
            CreateMap<EntidadFinancieraModificarCommand, EntidadFinanciera>();
            CreateMap<MonedaCrearCommand, Moneda>();
            CreateMap<MonedaModificarCommand, Moneda>();
            CreateMap<OrigenFinancieroCrearDto, OrigenFinanciero>();
            CreateMap<PuntoFinancieroCrearDto, PuntoFinanciero>();
            CreateMap<TerceroCrearDto, Tercero>();
            CreateMap<FinancieroCrearCommand, FinancieroCabecera>();
            CreateMap<FinancieroModificarCommand, FinancieroCabecera>();
            CreateMap<FinancieroDetalleEntrada, FinancieroDetalle>();
            CreateMap<FinancieroDetalleCrearCommand, FinancieroDetalle>();
            CreateMap<FinancieroDetalleModificarCommand, FinancieroDetalle>();
        }
    }
}
