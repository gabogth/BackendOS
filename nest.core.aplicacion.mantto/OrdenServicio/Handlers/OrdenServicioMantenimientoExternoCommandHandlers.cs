using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.mantto.OrdenServicio.Handlers
{
    public class OrdenServicioMantenimientoExternoRegistrarHandler
        : IRequestHandler<OrdenServicioMantenimientoExternoRegistrarCommand, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioMantenimientoExternoRegistrarHandler> logger;

        public OrdenServicioMantenimientoExternoRegistrarHandler(
            IOrdenServicioCabecera_MantenimientoExternoRepository repository,
            IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<OrdenServicioMantenimientoExternoRegistrarHandler> logger)
        {
            this.repository = repository;
            this.mantenimientoExternoRepository = mantenimientoExternoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(OrdenServicioMantenimientoExternoRegistrarCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                OrdenServicioCabecera cabeceraEntity = mapper.Map<OrdenServicioCabecera>(request.Cabecera);
                OrdenServicioCabecera cabecera = await repository.Agregar(cabeceraEntity);

                OrdenServicioMantenimientoExterno externoEntity = mapper.Map<OrdenServicioMantenimientoExterno>(request.Externo);
                externoEntity.Id = cabecera.Id;
                await mantenimientoExternoRepository.Agregar(externoEntity);

                await unitOfWork.CommitAsync(cancellationToken);
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                logger.LogError(ex, "Error al registrar la orden de servicio de mantenimiento externo");
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }

    public class OrdenServicioMantenimientoExternoActualizarHandler
        : IRequestHandler<OrdenServicioMantenimientoExternoActualizarCommand, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<OrdenServicioMantenimientoExternoActualizarHandler> logger;

        public OrdenServicioMantenimientoExternoActualizarHandler(
            IOrdenServicioCabecera_MantenimientoExternoRepository repository,
            IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<OrdenServicioMantenimientoExternoActualizarHandler> logger)
        {
            this.repository = repository;
            this.mantenimientoExternoRepository = mantenimientoExternoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(OrdenServicioMantenimientoExternoActualizarCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                OrdenServicioCabecera cabeceraEntity = mapper.Map<OrdenServicioCabecera>(request.Cabecera);
                cabeceraEntity.Id = request.Id;
                OrdenServicioCabecera cabecera = await repository.Modificar(cabeceraEntity);

                OrdenServicioMantenimientoExterno externoEntity = mapper.Map<OrdenServicioMantenimientoExterno>(request.Externo);
                externoEntity.Id = request.Id;
                await mantenimientoExternoRepository.Modificar(externoEntity);

                await unitOfWork.CommitAsync(cancellationToken);
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                logger.LogError(ex, "Error al actualizar la orden de servicio de mantenimiento externo {OrdenServicioId}", request.Id);
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }

    public class OrdenServicioMantenimientoExternoEliminarHandler
        : IRequestHandler<OrdenServicioMantenimientoExternoEliminarCommand, bool>
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly ILogger<OrdenServicioMantenimientoExternoEliminarHandler> logger;

        public OrdenServicioMantenimientoExternoEliminarHandler(
            IOrdenServicioCabecera_MantenimientoExternoRepository repository,
            ILogger<OrdenServicioMantenimientoExternoEliminarHandler> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task<bool> Handle(OrdenServicioMantenimientoExternoEliminarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.Eliminar(request.Id);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al eliminar la orden de servicio de mantenimiento externo {OrdenServicioId}", request.Id);
                throw;
            }
        }
    }
}
