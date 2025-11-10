using AutoMapper;
using nest.core.dominio.Logistica;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.dominio.Logistica.Transaccional;

namespace nest.core.aplicacion.logistica.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
        }

        private void MapAllEntities()
        {
            CreateMap<Almacen, Almacen>()
                .ForMember(dest => dest.Distrito, opt => opt.Ignore());
            CreateMap<InventarioCabecera, InventarioCabecera>()
                .ForMember(dest => dest.DocumentoTipo, opt => opt.Ignore())
                .ForMember(dest => dest.LogisticaTransaccion, opt => opt.Ignore())
                .ForMember(dest => dest.Almacen, opt => opt.Ignore())
                .ForMember(dest => dest.InventarioDetalles, opt => opt.Ignore());
            CreateMap<InventarioDetalle, InventarioDetalle>()
                .ForMember(dest => dest.Producto, opt => opt.Ignore())
                .ForMember(dest => dest.ProductoLote, opt => opt.Ignore())
                .ForMember(dest => dest.InventarioCabecera, opt => opt.Ignore());
            CreateMap<Producto, Producto>()
                .ForMember(dest => dest.UnidadMedidaCompra, opt => opt.Ignore())
                .ForMember(dest => dest.UnidadMedidaConsumo, opt => opt.Ignore());
            CreateMap<ProductoLote, ProductoLote>()
                .ForMember(dest => dest.Moneda, opt => opt.Ignore())
                .ForMember(dest => dest.Producto, opt => opt.Ignore());
            CreateMap<UnidadMedida, UnidadMedida>();
            CreateMap<LogisticaTransaccion, LogisticaTransaccion>();
        }
    }
}
