using AutoMapper;
using nest.core.aplicacion.finanzas.CuentaCorrientes.Commands;
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

namespace nest.core.aplicacion.finanzas.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
            CreateMap<FinancieroCabeceraCrearCommand, FinancieroCabecera>();
            CreateMap<FinancieroCabeceraModificarCommand, FinancieroCabecera>();
            CreateMap<EntidadFinancieraCrearCommand, EntidadFinanciera>();
            CreateMap<EntidadFinancieraModificarCommand, EntidadFinanciera>();
            CreateMap<FinancieroDetalleCrearCommand, FinancieroDetalle>();
            CreateMap<FinancieroDetalleModificarCommand, FinancieroDetalle>();
            CreateMap<TerceroCrearCommand, Tercero>();
            CreateMap<TerceroModificarCommand, Tercero>();
            CreateMap<PuntoFinancieroCrearCommand, PuntoFinanciero>();
            CreateMap<PuntoFinancieroModificarCommand, PuntoFinanciero>();
            CreateMap<CuentaCorrienteCrearCommand, CuentaCorriente>();
            CreateMap<CuentaCorrienteModificarCommand, CuentaCorriente>();
            CreateMap<MonedaCrearCommand, Moneda>();
            CreateMap<MonedaModificarCommand, Moneda>();
            CreateMap<OrigenFinancieroCrearCommand, OrigenFinanciero>();
            CreateMap<OrigenFinancieroModificarCommand, OrigenFinanciero>();
        }

        private void MapAllEntities()
        {
            CreateMap<FinancieroCabecera, FinancieroCabecera>()
                .ForMember(dest => dest.PuntoFinanciero, opt => opt.Ignore())
                .ForMember(dest => dest.OrigenFinanciero, opt => opt.Ignore())
                .ForMember(dest => dest.TerceroGen, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentoTipoGen, opt => opt.Ignore())
                .ForMember(dest => dest.FinancieroDetalles, opt => opt.Ignore());
            CreateMap<EntidadFinanciera, EntidadFinanciera>();
            CreateMap<FinancieroDetalle, FinancieroDetalle>()
                .ForMember(dest => dest.FinancieroCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.Tercero, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentoTipo, opt => opt.Ignore())
                .ForMember(dest => dest.CuentaCorriente, opt => opt.Ignore());
            CreateMap<Tercero, Tercero>()
                .ForMember(dest => dest.DocumentoIdentidadTipoFinanciero, opt => opt.Ignore())
                .ForMember(dest => dest.CuentaContablePorCobrar, opt => opt.Ignore())
                .ForMember(dest => dest.CuentaContablePorPagar, opt => opt.Ignore())
                .ForMember(dest => dest.Persona, opt => opt.Ignore());
            CreateMap<PuntoFinanciero, PuntoFinanciero>();
            CreateMap<CuentaCorriente, CuentaCorriente>()
                .ForMember(dest => dest.EntidadFinanciera, opt => opt.Ignore())
                .ForMember(dest => dest.CuentaContable, opt => opt.Ignore());
            CreateMap<Moneda, Moneda>();
            CreateMap<OrigenFinanciero, OrigenFinanciero>();
        }
    }
}
