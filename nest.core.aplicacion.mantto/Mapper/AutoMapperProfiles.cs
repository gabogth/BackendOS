using AutoMapper;
using nest.core.aplicacion.mantto.Labores.Commands;
using nest.core.aplicacion.mantto.MantenimientoTipos.Commands;
using nest.core.aplicacion.mantto.OrdenServicioCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenServicioMantenimientoExternos.Commands;
using nest.core.aplicacion.mantto.OrdenServicioTipos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoCabeceras.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoHorarios.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.LaborEntities;
using nest.core.dominio.Mantto.MantenimientoTipoEntities;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenServicioTipoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;

namespace nest.core.aplicacion.mantto.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
            CreateMap<LaborCrearCommand, Labor>();
            CreateMap<LaborModificarCommand, Labor>();
            CreateMap<MantenimientoTipoCrearCommand, MantenimientoTipo>();
            CreateMap<MantenimientoTipoModificarCommand, MantenimientoTipo>();
            CreateMap<OrdenServicioCabeceraCrearCommand, OrdenServicioCabecera>();
            CreateMap<OrdenServicioCabeceraModificarCommand, OrdenServicioCabecera>();
            CreateMap<OrdenServicioMantenimientoExternoCrearCommand, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioMantenimientoExternoModificarCommand, OrdenServicioMantenimientoExterno>();
            CreateMap<OrdenServicioTipoCrearCommand, OrdenServicioTipo>();
            CreateMap<OrdenServicioTipoModificarCommand, OrdenServicioTipo>();
            CreateMap<OrdenTrabajoCabeceraCrearCommand, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoCabeceraModificarCommand, OrdenTrabajoCabecera>();
            CreateMap<OrdenTrabajoDetalleActivoCrearCommand, OrdenTrabajoDetalleActivo>();
            CreateMap<OrdenTrabajoDetalleActivoModificarCommand, OrdenTrabajoDetalleActivo>();
            CreateMap<OrdenTrabajoDetalleCrearCommand, OrdenTrabajoDetalle>();
            CreateMap<OrdenTrabajoDetalleModificarCommand, OrdenTrabajoDetalle>();
            CreateMap<OrdenTrabajoPersonalCrearCommand, OrdenTrabajoPersonal>();
            CreateMap<OrdenTrabajoPersonalModificarCommand, OrdenTrabajoPersonal>();
            CreateMap<OrdenTrabajoHorarioCrearCommand, OrdenTrabajoHorario>();
            CreateMap<OrdenTrabajoHorarioModificarCommand, OrdenTrabajoHorario>();
        }

        private void MapAllEntities()
        {
            CreateMap<Labor, Labor>();
            CreateMap<MantenimientoTipo, MantenimientoTipo>();
            CreateMap<OrdenServicioCabecera, OrdenServicioCabecera>()
                .ForMember(dest => dest.OrdenServicioTipo, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenServicioMantenimientoExterno, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoCabeceras, opt => opt.Ignore());
            CreateMap<OrdenServicioMantenimientoExterno, OrdenServicioMantenimientoExterno>()
                .ForMember(dest => dest.Cliente, opt => opt.Ignore())
                .ForMember(dest => dest.ClienteSupervisor, opt => opt.Ignore())
                .ForMember(dest => dest.Contrato, opt => opt.Ignore())
                .ForMember(dest => dest.ClientePlanner, opt => opt.Ignore())
                .ForMember(dest => dest.ActaConformidad, opt => opt.Ignore())
                .ForMember(dest => dest.Moneda, opt => opt.Ignore())
                .ForMember(dest => dest.MantenimientoTipo, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenServicioCabecera, opt => opt.Ignore());
            CreateMap<OrdenServicioTipo, OrdenServicioTipo>();
            CreateMap<OrdenTrabajoCabecera, OrdenTrabajoCabecera>()
                .ForMember(dest => dest.OrdenServicioCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoCabeceraPadre, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoTrabajo, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoDetalles, opt => opt.Ignore())
                .ForMember(dest => dest.Personales, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoHorarios, opt => opt.Ignore());
            CreateMap<OrdenTrabajoDetalleActivo, OrdenTrabajoDetalleActivo>()
                .ForMember(dest => dest.OrdenTrabajoDetalle, opt => opt.Ignore())
                .ForMember(dest => dest.Activo, opt => opt.Ignore());
            CreateMap<OrdenTrabajoDetalle, OrdenTrabajoDetalle>()
                .ForMember(dest => dest.OrdenTrabajoCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.UbicacionTecnica, opt => opt.Ignore())
                .ForMember(dest => dest.Labor, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoDetalleActivo, opt => opt.Ignore());
            CreateMap<OrdenTrabajoPersonal, OrdenTrabajoPersonal>()
                .ForMember(dest => dest.OrdenTrabajoCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.Persona, opt => opt.Ignore());
            CreateMap<OrdenTrabajoHorario, OrdenTrabajoHorario>()
                .ForMember(dest => dest.OrdenTrabajoCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.Personal, opt => opt.Ignore())
                .ForMember(dest => dest.HorarioCabecera, opt => opt.Ignore());
        }
    }
}
