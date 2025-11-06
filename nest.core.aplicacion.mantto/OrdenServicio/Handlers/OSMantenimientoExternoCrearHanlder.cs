using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenServicio.Commands;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.mantto.OrdenServicio.Handlers
{
    public class OSMantenimientoExternoCrearHanlder : IRequestHandler<OSMantenimientoExternoCrearCommand, OrdenServicioCabecera>
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<OSMantenimientoExternoCrearHanlder> logger;

        public OSMantenimientoExternoCrearHanlder(IOrdenServicioCabecera_MantenimientoExternoRepository repository,
            IOrdenServicioMantenimientoExternoRepository mantenimientoExternoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<OSMantenimientoExternoCrearHanlder> logger)
        {
            this.repository = repository;
            this.mantenimientoExternoRepository = mantenimientoExternoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<OrdenServicioCabecera> Handle(OSMantenimientoExternoCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var cabeceraDto = mapper.Map<OrdenServicioCabecera>(request.Cabecera);
                var cabecera = await repository.Agregar(cabeceraDto);

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
}
