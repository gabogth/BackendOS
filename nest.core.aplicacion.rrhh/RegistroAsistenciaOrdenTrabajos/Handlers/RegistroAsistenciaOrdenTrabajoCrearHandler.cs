using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers;
using nest.core.aplication.auth;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.RRHH.HorarioCabeceraEntities;
using nest.core.dominio.RRHH.HorarioDetalleEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.rrhh;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Handlers
{
    public class RegistroAsistenciaOrdenTrabajoCrearHandler : RegistroAsistenciaHandlerBase, IRequestHandler<RegistroAsistenciaOrdenTrabajoCrearCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository;
        private readonly IOrdenTrabajoCabeceraRepository ordenTrabajoCabeceraRepository;
        private readonly IRegistroAsistenciaAdjuntoRepository registroAsistenciaAdjuntoRepository;
        private readonly IOrdenTrabajoHorarioRepository ordenTrabajoHorarioRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaOrdenTrabajoCrearHandler> logger;

        public RegistroAsistenciaOrdenTrabajoCrearHandler(
            IRegistroAsistencia_OrdenTrabajoRepository repository,
            IHorarioRepository horarioRepository,
            IPersonalRepository personalRepository,
            IHorarioDetalleRepository horarioDetalleRepository,
            IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository,
            IOrdenTrabajoCabeceraRepository ordenTrabajoCabeceraRepository,
            IRegistroAsistenciaAdjuntoRepository registroAsistenciaAdjuntoRepository,
            IOrdenTrabajoHorarioRepository ordenTrabajoHorarioRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<RegistroAsistenciaOrdenTrabajoCrearHandler> logger)
            : base(repository, horarioRepository, personalRepository, horarioDetalleRepository)
        {
            this.registroOrdenTrabajoRepository = registroOrdenTrabajoRepository;
            this.ordenTrabajoCabeceraRepository = ordenTrabajoCabeceraRepository;
            this.registroAsistenciaAdjuntoRepository = registroAsistenciaAdjuntoRepository;
            this.ordenTrabajoHorarioRepository = ordenTrabajoHorarioRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaOrdenTrabajoCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var registro = mapper.Map<RegistroAsistencia>(request);
                var personal = await personalRepository.ObtenerPorId(registro.PersonalId);
                var otHorario = await ordenTrabajoHorarioRepository.ObtenerPorPersonalYFecha(registro.PersonalId, registro.Fecha);

                HorarioCabecera horarioActual = otHorario == null ? personal.HorarioCabecera : otHorario.HorarioCabecera;
                registro = await PrepararRegistroAsync(registro, horarioActual);
                registro = await repository.Agregar(registro);

                if (otHorario != null)
                {
                    var relacion = new RegistroAsistenciaOrdenTrabajo
                    {
                        EmpresaId = registro.EmpresaId,
                        Id = registro.Id,
                        OrdenTrabajoCabeceraId = horarioActual.Id
                    };
                    await registroOrdenTrabajoRepository.Agregar(relacion);
                }
                var adjunto = new RegistroAsistenciaAdjunto
                {
                    EmpresaId = registro.EmpresaId,
                    Id = registro.Id,
                    AdjuntoId = request.AdjuntoId
                };
                await registroAsistenciaAdjuntoRepository.Agregar(adjunto);

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                logger.LogError(ex, "Error al registrar asistencia de orden de trabajo para el personal {PersonalId}", request.PersonalId);
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
