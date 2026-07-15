using AutoMapper;
using nest.core.aplicacion.rrhh.Cargos.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajoPersonas.Commands;
using nest.core.aplicacion.rrhh.GrupoTrabajos.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalleEventos.Commands;
using nest.core.aplicacion.rrhh.HorarioDetalles.Commands;
using nest.core.aplicacion.rrhh.Horarios.Commands;
using nest.core.aplicacion.rrhh.Personales.Commands;
using nest.core.aplicacion.rrhh.PersonalEstados.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaAdjuntos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Commands;
using nest.core.aplicacion.rrhh.TerminalBiometricos.Commands;
using nest.core.dominio.RRHH.CargoEntities;
using nest.core.dominio.RRHH.FrecuenciaPagoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoEntities;
using nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.HorarioDetalleEventoEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.PersonalEstadoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;
using nest.core.dominio.RRHH.TerminalBiometricoEntities;

namespace nest.core.aplicacion.rrhh.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            MapAllEntities();
            CreateMap<CargoCrearCommand, Cargo>();
            CreateMap<CargoModificarCommand, Cargo>();
            CreateMap<HorarioCrearCommand, HorarioCabecera>();
            CreateMap<HorarioModificarCommand, HorarioCabecera>();
            CreateMap<PersonalCrearCommand, Personal>();
            CreateMap<PersonalModificarCommand, Personal>();
            CreateMap<HorarioDetalleEventoCrearCommand, HorarioDetalleEvento>();
            CreateMap<HorarioDetalleEventoModificarCommand, HorarioDetalleEvento>();
            CreateMap<HorarioDetalleCrearCommand, HorarioDetalle>();
            CreateMap<HorarioDetalleModificarCommand, HorarioDetalle>();
            CreateMap<GrupoTrabajoCrearCommand, GrupoTrabajo>();
            CreateMap<GrupoTrabajoModificarCommand, GrupoTrabajo>();
            CreateMap<GrupoTrabajoPersonaCrearCommand, GrupoTrabajoPersona>();
            CreateMap<GrupoTrabajoPersonaModificarCommand, GrupoTrabajoPersona>();
            CreateMap<PersonalEstadoCrearCommand, PersonalEstado>();
            CreateMap<PersonalEstadoModificarCommand, PersonalEstado>();
            CreateMap<RegistroAsistenciaCrearCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaCrearUsuarioActualCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaModificarCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaOrdenTrabajoCrearCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaOrdenTrabajoCrearUsuarioActualCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaOrdenTrabajoModificarCommand, RegistroAsistencia>();
            CreateMap<RegistroAsistenciaPoliticaCrearCommand, RegistroAsistenciaPolitica>();
            CreateMap<RegistroAsistenciaPoliticaModificarCommand, RegistroAsistenciaPolitica>();
            CreateMap<RegistroAsistenciaAdjuntoCrearCommand, RegistroAsistenciaAdjunto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RegistroAsistenciaId));
            CreateMap<RegistroAsistenciaAdjuntoModificarCommand, RegistroAsistenciaAdjunto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RegistroAsistenciaId));
            CreateMap<TerminalBiometricoCrearCommand, TerminalBiometrico>();
            CreateMap<TerminalBiometricoModificarCommand, TerminalBiometrico>();
            CreateMap<HorarioCabecera, HorarioCabecera>();
        }

        private void MapAllEntities()
        {
            CreateMap<Cargo, Cargo>();
            CreateMap<FrecuenciaPago, FrecuenciaPago>();
            CreateMap<GrupoTrabajo, GrupoTrabajo>()
                .ForMember(dest => dest.GrupoTrabajoPersonas, opt => opt.Ignore());
            CreateMap<GrupoTrabajoPersona, GrupoTrabajoPersona>()
                .ForMember(dest => dest.Persona, opt => opt.Ignore())
                .ForMember(dest => dest.GrupoTrabajo, opt => opt.Ignore());
            CreateMap<HorarioCabecera, HorarioCabecera>()
                .ForMember(dest => dest.HorarioDetalles, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoHorarios, opt => opt.Ignore());
            CreateMap<HorarioDetalle, HorarioDetalle>()
                .ForMember(dest => dest.HorarioCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.HorarioDetalleEventos, opt => opt.Ignore());
            CreateMap<HorarioDetalleEvento, HorarioDetalleEvento>()
                .ForMember(dest => dest.HorarioDetalle, opt => opt.Ignore());
            CreateMap<Personal, Personal>()
                .ForMember(dest => dest.HorarioCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.RegistroAsistenciaPolitica, opt => opt.Ignore())
                .ForMember(dest => dest.ContratoCabecera, opt => opt.Ignore())
                .ForMember(dest => dest.Persona, opt => opt.Ignore())
                .ForMember(dest => dest.PersonalEstado, opt => opt.Ignore())
                .ForMember(dest => dest.Superior, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore())
                .ForMember(dest => dest.Usuario, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoHorarios, opt => opt.Ignore());
            CreateMap<PersonalEstado, PersonalEstado>();
            CreateMap<RegistroAsistenciaAdjunto, RegistroAsistenciaAdjunto>()
                .ForMember(dest => dest.RegistroAsistencia, opt => opt.Ignore())
                .ForMember(dest => dest.Adjunto, opt => opt.Ignore());
            CreateMap<RegistroAsistencia, RegistroAsistencia>()
                .ForMember(dest => dest.Personal, opt => opt.Ignore())
                .ForMember(dest => dest.HorarioDetalleEvento, opt => opt.Ignore())
                .ForMember(dest => dest.RegistroAsistenciaPolitica, opt => opt.Ignore())
                .ForMember(dest => dest.RegistroAsistenciaOrdenTrabajo, opt => opt.Ignore())
                .ForMember(dest => dest.RegistroAsistenciaAdjunto, opt => opt.Ignore());
            CreateMap<RegistroAsistenciaOrdenTrabajo, RegistroAsistenciaOrdenTrabajo>()
                .ForMember(dest => dest.RegistroAsistencia, opt => opt.Ignore())
                .ForMember(dest => dest.OrdenTrabajoCabecera, opt => opt.Ignore());
            CreateMap<RegistroAsistenciaPolitica, RegistroAsistenciaPolitica>();
            CreateMap<TerminalBiometrico, TerminalBiometrico>();
        }
    }
}
