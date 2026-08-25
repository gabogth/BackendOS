using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Handlers;
using nest.core.aplicacion.rrhh.RegistroAsistencias.Services.Interface;
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
    public class RegistroAsistenciaOrdenTrabajoCrearHandler : IRequestHandler<RegistroAsistenciaOrdenTrabajoCrearCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistencia_OrdenTrabajoRepository repository;
        private readonly IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository;
        private readonly IRegistroAsistenciaAdjuntoRepository registroAsistenciaAdjuntoRepository;
        private readonly IMarcacionCalculoService calculoService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<RegistroAsistenciaOrdenTrabajoCrearHandler> logger;

        public RegistroAsistenciaOrdenTrabajoCrearHandler(
            IRegistroAsistencia_OrdenTrabajoRepository repository,
            IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository,
            IRegistroAsistenciaAdjuntoRepository registroAsistenciaAdjuntoRepository,
            IMarcacionCalculoService calculoService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<RegistroAsistenciaOrdenTrabajoCrearHandler> logger)
        {
            this.repository = repository;
            this.registroOrdenTrabajoRepository = registroOrdenTrabajoRepository;
            this.registroAsistenciaAdjuntoRepository = registroAsistenciaAdjuntoRepository;
            this.calculoService = calculoService;
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
                var calculo = await calculoService.PrepararRegistroOrdenTrabajoAsync(registro);
                registro = calculo.Registro;
                var otHorario = calculo.OrdenTrabajoHorario;
                registro = await repository.Agregar(registro);

                if (otHorario != null)
                {
                    var relacion = new RegistroAsistenciaOrdenTrabajo
                    {
                        EmpresaId = registro.EmpresaId,
                        Id = registro.Id,
                        OrdenTrabajoCabeceraId = otHorario.OrdenTrabajoCabeceraId
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
