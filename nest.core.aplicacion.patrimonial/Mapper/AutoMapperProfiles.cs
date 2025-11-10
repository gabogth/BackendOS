using AutoMapper;
using nest.core.aplicacion.patrimonial.Activos.Commands;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.aplicacion.patrimonial.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
            CreateMap<ActivoCrearCommand, Activo>();
            CreateMap<ActivoModificarCommand, Activo>();
            CreateMap<UbicacionActivoCrearCommand, UbicacionActivo>();
            CreateMap<UbicacionActivoModificarCommand, UbicacionActivo>();
            CreateMap<UbicacionTecnicaCrearCommand, UbicacionTecnica>();
            CreateMap<UbicacionTecnicaModificarCommand, UbicacionTecnica>();
        }

        private void MapAllEntities()
        {
            CreateMap<Activo, Activo>()
                .ForMember(dest => dest.ProductoLote, opt => opt.Ignore())
                .ForMember(dest => dest.CentroDeCostos, opt => opt.Ignore())
                .ForMember(dest => dest.Tercero, opt => opt.Ignore());
            CreateMap<UbicacionActivo, UbicacionActivo>()
                .ForMember(dest => dest.Activo, opt => opt.Ignore())
                .ForMember(dest => dest.UbicacionTecnica, opt => opt.Ignore())
                .ForMember(dest => dest.ContratoCabecera, opt => opt.Ignore());
            CreateMap<UbicacionTecnica, UbicacionTecnica>()
                .ForMember(dest => dest.Tercero, opt => opt.Ignore())
                .ForMember(dest => dest.Padre, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore());
        }
    }
}
