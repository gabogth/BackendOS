using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.mantto.OrdenServicio.Handlers
{
    public class OSMantenimientoExternoModificarHandler : IRequestHandler<OSMantenimientoExternoModificarCommand, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<OSMantenimientoExternoModificarHandler> logger;

        public OSMantenimientoExternoModificarHandler(IOrdenServicioCabecera_MantenimientoExternoRepository repository,
            IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<OSMantenimientoExternoModificarHandler> logger)
        {
            this.repository = repository;
            this.mantenimientoExternoRepository = mantenimientoExternoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(OSMantenimientoExternoModificarCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var cabeceraDto = mapper.Map<OrdenServicioCabecera>(request.Cabecera);
                cabeceraDto.Id = request.Id;
                OrdenServicioCabecera cabecera = await repository.Modificar(cabeceraDto);

                var existMantto = mantenimientoExternoRepository.ObtenerPorId(cabecera.Id);
                OrdenServicioMantenimientoExterno externoDto = mapper.Map<OrdenServicioMantenimientoExterno>(request.Externo);
                externoDto.Id = request.Id;
                if (existMantto != null)
                    await mantenimientoExternoRepository.Modificar(externoDto);
                else
                    await mantenimientoExternoRepository.Agregar(externoDto);
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
}
