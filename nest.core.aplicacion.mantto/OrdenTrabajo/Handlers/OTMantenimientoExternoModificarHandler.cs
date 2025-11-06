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
    public class OTMantenimientoExternoModificarHandler : IRequestHandler<OTMantenimientoExternoModificarCommand, OrdenTrabajoCabecera>
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenTrabajoDetalleRepository detalleRepository;
        private readonly IOrdenTrabajoDetalleActivoRepository detalleActivoRepository;
        private readonly IOrdenTrabajoPersonalRepository ordenTrabajoPersonalRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IValidator<OrdenTrabajoMantenimientoExternoRegistroCommand> validator;
        private readonly ILogger<OTMantenimientoExternoModificarHandler> logger;

        public OTMantenimientoExternoModificarHandler(
            IOrdenTrabajoCabecera_MantenimientoExternoRepository repository,
            IOrdenTrabajoDetalleRepository detalleRepository,
            IOrdenTrabajoDetalleActivoRepository detalleActivoRepository,
            IOrdenTrabajoPersonalRepository ordenTrabajoPersonalRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<OrdenTrabajoMantenimientoExternoRegistroCommand> validator,
            ILogger<OTMantenimientoExternoModificarHandler> logger)
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

        public async Task<OrdenTrabajoCabecera> Handle(OTMantenimientoExternoModificarCommand request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            await unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                OrdenTrabajoCabecera cabeceraEntity = mapper.Map<OrdenTrabajoCabecera>(request.Cabecera);
                cabeceraEntity.Id = request.Id;
                OrdenTrabajoCabecera cabecera = await repository.Modificar(cabeceraEntity);
                cabecera = await repository.ObtenerPorId(cabecera.Id);

                OrdenTrabajoPersonal[] originalesPersonas = cabecera.Personales.ToArray();
                OrdenTrabajoDetalle[] originalesDetalles = cabecera.OrdenTrabajoDetalles.ToArray();
                OrdenTrabajoDetalleActivo[] originalesActivos = originalesDetalles
                    .Select(x => x.OrdenTrabajoDetalleActivo)
                    .ToArray();

                OrdenTrabajoPersonal[] personasActualizadas = request.Personas
                    .Select(personaDto =>
                    {
                        var modificarPersonaCommand = new OrdenTrabajoPersonalModificarCommand(
                            personaDto.Id,
                            cabecera.EmpresaId,
                            cabecera.Id,
                            personaDto.PersonaId,
                            personaDto.EsLider
                        );

                        return mapper.Map<OrdenTrabajoPersonal>(modificarPersonaCommand);
                    })
                    .ToArray();
                await ordenTrabajoPersonalRepository.FusionarRange(originalesPersonas, personasActualizadas);

                OrdenTrabajoMantenimientoExternoDetalleRegistro[] detallesEntrada = request.Detalles.ToArray();
                OrdenTrabajoDetalle[] detallesActualizados = detallesEntrada
                    .Select(detalleEntrada =>
                    {
                        var detalleDto = detalleEntrada.Detalle with
                        {
                            EmpresaId = cabecera.EmpresaId,
                            OrdenTrabajoCabeceraId = cabecera.Id
                        };

                        var modificarDetalleCommand = new OrdenTrabajoDetalleModificarCommand(
                            detalleDto.Id,
                            detalleDto.EmpresaId,
                            detalleDto.OrdenTrabajoCabeceraId,
                            detalleDto.UbicacionTecnicaId,
                            detalleDto.LaborId,
                            detalleDto.HorasProyectadas,
                            detalleDto.HorasEjecutadas,
                            detalleDto.Descripcion,
                            detalleDto.Estado
                        );

                        return mapper.Map<OrdenTrabajoDetalle>(modificarDetalleCommand);
                    })
                    .ToArray();
                OrdenTrabajoDetalle[] detalles = await detalleRepository.FusionarRange(originalesDetalles, detallesActualizados);

                OrdenTrabajoDetalleActivo[] activosActualizados = new OrdenTrabajoDetalleActivo[detallesEntrada.Length];
                for (int i = 0; i < detallesEntrada.Length; i++)
                {
                    var activo = detallesEntrada[i].Activo;
                    var modificarActivoCommand = new OrdenTrabajoDetalleActivoModificarCommand(
                        activo.Id,
                        cabecera.EmpresaId,
                        detalles[i].Id,
                        activo.ActivoId
                    );
                    activosActualizados[i] = mapper.Map<OrdenTrabajoDetalleActivo>(modificarActivoCommand);
                }
                await detalleActivoRepository.FusionarRange(originalesActivos, activosActualizados);

                await unitOfWork.CommitAsync(cancellationToken);
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync(cancellationToken);
                logger.LogError(ex, "Error al modificar la orden de trabajo de mantenimiento externo {OrdenTrabajoId}", request.Id);
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
