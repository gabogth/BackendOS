using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Services.Interface;
using nest.core.dominio.Mantto.OrdenTrabajoHorarioEntities;
using nest.core.dominio.RRHH.PersonalEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaAdjuntoEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Transaccional;
using nest.core.infraestructura.rrhh;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Handlers
{
    public class RegistroAsistenciaOrdenTrabajoRegularizarCrearHandler : IRequestHandler<RegistroAsistenciaOrdenTrabajoRegularizarCrearCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistencia_OrdenTrabajoRepository repository;
        private readonly IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository;
        private readonly IRegistroAsistenciaAdjuntoRepository registroAsistenciaAdjuntoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IPersonalRepository personalRepository;
        private readonly IConnectionStringService connectionStringService;
        private readonly ILogger<RegistroAsistenciaOrdenTrabajoRegularizarCrearHandler> logger;

        public RegistroAsistenciaOrdenTrabajoRegularizarCrearHandler(
            IRegistroAsistencia_OrdenTrabajoRepository repository,
            IPersonalRepository personalRepository,
            IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository,
            IRegistroAsistenciaAdjuntoRepository registroAsistenciaAdjuntoRepository,
            IOrdenTrabajoHorarioRepository ordenTrabajoHorarioRepository,
            IMarcacionCalculoService calculoService,
            IConnectionStringService connectionStringService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<RegistroAsistenciaOrdenTrabajoRegularizarCrearHandler> logger)
        {
            this.repository = repository;
            this.registroOrdenTrabajoRepository = registroOrdenTrabajoRepository;
            this.personalRepository = personalRepository;
            this.registroAsistenciaAdjuntoRepository = registroAsistenciaAdjuntoRepository;
            this.connectionStringService = connectionStringService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaOrdenTrabajoRegularizarCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var fecha = DateTime.Now;
                var registro = mapper.Map<RegistroAsistencia>(request);

                if(request.TipoRegularizacion == RegistroAsistenciaTipoRegularizacionId.Automatico)
                {
                    var personal = await personalRepository.ObtenerPorIdUsuario(connectionStringService.UserId);
                    registro.PersonalId = personal.Id;
                }

                registro.TipoEvento = request.EventoTipo;
                registro.FechaJornal = DateOnly.FromDateTime(fecha);
                registro.DiferenciaMinutos = 0;
                registro.EsTardanza = false;
                registro.HorarioDetalleEventoId = null;
                registro.RegistroAsistenciaPoliticaId = null;
                registro.Observacion = request.Observacion;

                if (request.OrdenTrabajoId.HasValue)
                {
                    var relacion = new RegistroAsistenciaOrdenTrabajo
                    {
                        EmpresaId = registro.EmpresaId,
                        Id = registro.Id,
                        OrdenTrabajoCabeceraId = request.OrdenTrabajoId.Value
                    };
                    await registroOrdenTrabajoRepository.Agregar(relacion);
                }
                if (request.AdjuntoId > 0) 
                {
                    var adjunto = new RegistroAsistenciaAdjunto
                    {
                        EmpresaId = registro.EmpresaId,
                        Id = registro.Id,
                        AdjuntoId = request.AdjuntoId
                    };
                    await registroAsistenciaAdjuntoRepository.Agregar(adjunto);
                }
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
