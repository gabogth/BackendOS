using System;
using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.mantto.OrdenTrabajo.Handlers
{
    public class OTMantenimientoExternoCrearHandler : IRequestHandler<OTMantenimientoExternoCrearCommand, OrdenTrabajoCabecera>
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenTrabajoDetalleRepository detalleRepository;
        private readonly IOrdenTrabajoDetalleActivoRepository detalleActivoRepository;
        private readonly IOrdenTrabajoPersonalRepository ordenTrabajoPersonalRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IValidator<OrdenTrabajoMantenimientoExternoRegistroCommand> validator;
        private readonly ILogger<OTMantenimientoExternoCrearHandler> logger;

        public OTMantenimientoExternoCrearHandler(
            IOrdenTrabajoCabecera_MantenimientoExternoRepository repository,
            IOrdenTrabajoDetalleRepository detalleRepository,
            IOrdenTrabajoDetalleActivoRepository detalleActivoRepository,
            IOrdenTrabajoPersonalRepository ordenTrabajoPersonalRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<OrdenTrabajoMantenimientoExternoRegistroCommand> validator,
            ILogger<OTMantenimientoExternoCrearHandler> logger)
        {
            this.repository = repository;
            this.detalleRepository = detalleRepository;
            this.detalleActivoRepository = detalleActivoRepository;
            this.ordenTrabajoPersonalRepository = ordenTrabajoPersonalRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validator = validator;
            this.logger = logger;
        }

        public async Task<OrdenTrabajoCabecera> Handle(OTMantenimientoExternoCrearCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                OrdenTrabajoCabecera cabeceraEntity = mapper.Map<OrdenTrabajoCabecera>(request.Cabecera);
                OrdenTrabajoCabecera cabecera = await repository.Agregar(cabeceraEntity);

                OrdenTrabajoPersonal[] personasEntities = request.Personas
                    .Select(personaDto =>
                    {
                        var personaCommand = personaDto with
                        {
                            EmpresaId = cabecera.EmpresaId,
                            OrdenTrabajoCabeceraId = cabecera.Id
                        };

                        return mapper.Map<OrdenTrabajoPersonal>(personaCommand);
                    })
                    .ToArray();
                await ordenTrabajoPersonalRepository.AgregarRange(personasEntities);

                OrdenTrabajoDetalle[] detalles = request.Detalles
                    .Select(detalleEntrada =>
                    {
                        var detalleDto = detalleEntrada.Detalle with
                        {
                            EmpresaId = cabecera.EmpresaId,
                            OrdenTrabajoCabeceraId = cabecera.Id
                        };

                        var crearDetalleCommand = new OrdenTrabajoDetalleCrearCommand(
                            detalleDto.EmpresaId,
                            detalleDto.OrdenTrabajoCabeceraId,
                            detalleDto.UbicacionTecnicaId,
                            detalleDto.LaborId,
                            detalleDto.HorasProyectadas,
                            detalleDto.HorasEjecutadas,
                            detalleDto.Descripcion,
                            detalleDto.Estado
                        );

                        return mapper.Map<OrdenTrabajoDetalle>(crearDetalleCommand);
                    })
                    .ToArray();

                OrdenTrabajoDetalle[] detallesInsertados = await detalleRepository.AgregarRange(detalles);

                OrdenTrabajoDetalleActivo[] activosCrear = new OrdenTrabajoDetalleActivo[request.Detalles.Count];
                for (int i = 0; i < request.Detalles.Count; i++)
                {
                    var activo = request.Detalles[i].Activo;
                    var crearActivoCommand = new OrdenTrabajoDetalleActivoCrearCommand(
                        cabecera.EmpresaId,
                        detallesInsertados[i].Id,
                        activo.ActivoId
                    );
                    activosCrear[i] = mapper.Map<OrdenTrabajoDetalleActivo>(crearActivoCommand);
                }
                await detalleActivoRepository.AgregarRange(activosCrear);

                await unitOfWork.CommitAsync(cancellationToken);
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                logger.LogError(ex, "Error al crear la orden de trabajo de mantenimiento externo");
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
