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
            CreateMap<Activo, Activo>();
            CreateMap<UbicacionActivo, UbicacionActivo>();
            CreateMap<UbicacionTecnica, UbicacionTecnica>();
        }
    }
}
