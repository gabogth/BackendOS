using AutoMapper;
using nest.core.aplicacion.finanzas.CuentaCorriente.Commands;
using nest.core.aplicacion.finanzas.EntidadFinancieras.Commands;
using nest.core.aplicacion.finanzas.FinancieroCabeceras.Commands;
using nest.core.aplicacion.finanzas.FinancieroDetalles.Commands;
using nest.core.aplicacion.finanzas.Monedas.Commands;
using nest.core.aplicacion.finanzas.OrigenFinancieros.Commands;
using nest.core.aplicacion.finanzas.PuntoFinancieros.Commands;
using nest.core.aplicacion.finanzas.Terceros.Commands;
using nest.core.dominio.Finanzas.ClienteEntities;
using nest.core.dominio.Finanzas.CuentaCorrienteEntities;
using nest.core.dominio.Finanzas.EntidadFinancieraEntities;
using nest.core.dominio.Finanzas.FinancieroCabeceraEntities;
using nest.core.dominio.Finanzas.FinancieroDetalleEntities;
using nest.core.dominio.Finanzas.MonedaEntities;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

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
            CreateMap<OrigenFinancieroCrearCommand, OrigenFinanciero>();
            CreateMap<OrigenFinancieroModificarCommand, OrigenFinanciero>();
            CreateMap<PuntoFinancieroCrearCommand, PuntoFinanciero>();
            CreateMap<PuntoFinancieroModificarCommand, PuntoFinanciero>();
            CreateMap<TerceroCrearCommand, Tercero>();
            CreateMap<TerceroModificarCommand, Tercero>();
            CreateMap<FinancieroCabeceraCrearCommand, FinancieroCabecera>();
            CreateMap<FinancieroCabeceraModificarCommand, FinancieroCabecera>();
            CreateMap<FinancieroDetalleCrearCommand, FinancieroDetalle>();
            CreateMap<FinancieroDetalleModificarCommand, FinancieroDetalle>();
        }
    }
}
