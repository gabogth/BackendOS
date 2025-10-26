using AutoMapper;
using nest.core.aplicacion.patrimonial.Activos.Commands;
using nest.core.aplicacion.patrimonial.UbicacionActivos.Commands;
using nest.core.aplicacion.patrimonial.UbicacionTecnicas.Commands;
using nest.core.dominio.Patrimonial.ActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;

namespace nest.core.infraestructura.patrimonial.Mapper
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ActivoCrearCommand, Activo>();
            CreateMap<ActivoModificarCommand, Activo>();
            CreateMap<UbicacionActivoCrearCommand, UbicacionActivo>();
            CreateMap<UbicacionActivoModificarCommand, UbicacionActivo>();
            CreateMap<UbicacionTecnicaCrearCommand, UbicacionTecnica>();
            CreateMap<UbicacionTecnicaModificarCommand, UbicacionTecnica>();
        }
    }
}
