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
            CreateMap<Almacen, Almacen>();
            CreateMap<InventarioCabecera, InventarioCabecera>();
            CreateMap<InventarioDetalle, InventarioDetalle>();
            CreateMap<Producto, Producto>();
            CreateMap<ProductoLote, ProductoLote>();
            CreateMap<UnidadMedida, UnidadMedida>();
            CreateMap<LogisticaTransaccion, LogisticaTransaccion>();
        }
    }
}
