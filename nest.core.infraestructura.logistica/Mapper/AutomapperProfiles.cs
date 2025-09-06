using AutoMapper;
using nest.core.dominio.Logistica.AlmacenEN;
using nest.core.dominio.Logistica.OrdenServicio;

namespace nest.core.infraestructura.logistica.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<AlmacenCrearDto, Almacen>();
            CreateMap<OrdenServicioCabeceraCrearDto, OrdenServicioCabecera>();
            CreateMap<OrdenServicioMantenimientoExternoCrearDto, OrdenServicioMantenimientoExterno>();
        }
    }
}
