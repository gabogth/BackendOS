using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaEntities;
using nest.core.dominio.RRHH.RegistroAsistenciaOrdenTrabajoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaOrdenTrabajos.Handlers
{
    public class RegistroAsistenciaOrdenTrabajoRegularizarModificarHandler : IRequestHandler<RegistroAsistenciaOrdenTrabajoRegularizarModificarCommand, RegistroAsistencia>
    {
        private readonly IRegistroAsistencia_OrdenTrabajoRepository repository;
        private readonly IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<RegistroAsistenciaOrdenTrabajoRegularizarCrearHandler> logger;

        public RegistroAsistenciaOrdenTrabajoRegularizarModificarHandler(
            IRegistroAsistencia_OrdenTrabajoRepository repository,
            IRegistroAsistenciaOrdenTrabajoRepository registroOrdenTrabajoRepository,
            IUnitOfWork unitOfWork,
            ILogger<RegistroAsistenciaOrdenTrabajoRegularizarCrearHandler> logger)
        {
            this.repository = repository;
            this.registroOrdenTrabajoRepository = registroOrdenTrabajoRepository;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<RegistroAsistencia> Handle(RegistroAsistenciaOrdenTrabajoRegularizarModificarCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var registro = await repository.ObtenerPorId(request.RegistroAsistenciaId);
                registro.Fecha = request.Fecha ?? registro.Fecha;
                registro.TipoEvento = request.EventoTipo;
                registro.FechaJornal = request.FechaJornal ?? registro.FechaJornal;
                registro.Observacion = request.Observacion ?? registro.Observacion;
                await repository.Modificar(registro);
                

                if (request.OrdenTrabajoId.HasValue)
                {
                    var registroOrdenTrabajo = await registroOrdenTrabajoRepository.ObtenerPorId(request.RegistroAsistenciaId);
                    if (registroOrdenTrabajo != null)
                    {
                        registroOrdenTrabajo.OrdenTrabajoCabeceraId = request.OrdenTrabajoId ?? registroOrdenTrabajo.OrdenTrabajoCabeceraId;
                        var nuevaOt = await registroOrdenTrabajoRepository.Modificar(registroOrdenTrabajo);
                    }
                    else
                    {
                        var relacion = new RegistroAsistenciaOrdenTrabajo
                        {
                            EmpresaId = registro.EmpresaId,
                            Id = registro.Id,
                            OrdenTrabajoCabeceraId = request.OrdenTrabajoId.Value
                        };
                        await registroOrdenTrabajoRepository.Agregar(relacion);
                    }
                }
                else
                {
                    var existe = await registroOrdenTrabajoRepository.ObtenerPorId(registro.Id);
                    if (existe != null)
                        await registroOrdenTrabajoRepository.Eliminar(registro.Id);
                }
                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(registro.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                logger.LogError(ex, "Error al registrar asistencia de orden de trabajo para el personal");
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
