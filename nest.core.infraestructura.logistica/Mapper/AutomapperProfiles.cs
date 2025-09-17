using AutoMapper;
using nest.core.dominio.Logistica.AlmacenEN;

namespace nest.core.infraestructura.logistica.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<AlmacenCrearDto, Almacen>();
        }
    }
}
