using AutoMapper;
using FluentValidation;
using nest.core.aplicacion.mantto.OrdenTrabajo.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalleActivos.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoDetalles.Commands;
using nest.core.aplicacion.mantto.OrdenTrabajoPersonales.Commands;
using nest.core.dominio.Mantto.OrdenTrabajoCabeceraEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleActivoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoDetalleEntities;
using nest.core.dominio.Mantto.OrdenTrabajoMantenimientoExternoEntities;
using nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.mantto.OrdenTrabajo
{
    public class OrdenTrabajoMantenimientoExternoService
    {
        private readonly IOrdenTrabajoCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenTrabajoDetalleRepository detalleRepository;
        private readonly IOrdenTrabajoDetalleActivoRepository detalleActivoRepository;
        private readonly IOrdenTrabajoPersonalRepository ordenTrabajoPersonalRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IValidator<OrdenTrabajoMantenimientoExternoRegistroCommand> validator;

        public OrdenTrabajoMantenimientoExternoService(
            IOrdenTrabajoCabecera_MantenimientoExternoRepository repository,
            IOrdenTrabajoDetalleRepository detalleRepository,
            IOrdenTrabajoDetalleActivoRepository detalleActivoRepository,
            IOrdenTrabajoPersonalRepository ordenTrabajoPersonalRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IValidator<OrdenTrabajoMantenimientoExternoRegistroCommand> validator)
        {
            this.repository = repository;
            this.detalleRepository = detalleRepository;
            this.detalleActivoRepository = detalleActivoRepository;
            this.ordenTrabajoPersonalRepository = ordenTrabajoPersonalRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validator = validator;
        }

        public Task<OrdenTrabajoCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoCabecera>> ObtenerTodos() => repository.ObtenerTodos();

        public Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId) => repository.ObtenerPorOrdenServicio(ordenServicioCabeceraId);

        public async Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoMantenimientoExternoRegistroCommand command)
        {
            await validator.ValidateAndThrowAsync(command);
            await unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenTrabajoCabecera cabeceraEntity = mapper.Map<OrdenTrabajoCabecera>(command.Cabecera);
                OrdenTrabajoCabecera cabecera = await repository.Agregar(cabeceraEntity);
                List<OrdenTrabajoMantenimientoExternoDetalleRegistro> detallesEntrada = command.Detalles;

                OrdenTrabajoPersonal[] personasEntities = command.Personas
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

                OrdenTrabajoDetalle[] detalles = detallesEntrada
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

                OrdenTrabajoDetalleActivo[] activosCrear = new OrdenTrabajoDetalleActivo[detallesEntrada.Count];
                for (int i = 0; i < detallesEntrada.Count; i++)
                {
                    OrdenTrabajoMantenimientoExternoDetalleActivoRegistro activo = detallesEntrada[i].Activo;
                    var crearActivoCommand = new OrdenTrabajoDetalleActivoCrearCommand(
                        cabecera.EmpresaId,
                        detallesInsertados[i].Id,
                        activo.ActivoId
                    );
                    activosCrear[i] = mapper.Map<OrdenTrabajoDetalleActivo>(crearActivoCommand);
                }
                await detalleActivoRepository.AgregarRange(activosCrear);

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public async Task<OrdenTrabajoCabecera> Modificar(long id, OrdenTrabajoMantenimientoExternoRegistroCommand command)
        {
            await validator.ValidateAndThrowAsync(command);
            await unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenTrabajoCabecera cabeceraEntity = mapper.Map<OrdenTrabajoCabecera>(command.Cabecera);
                cabeceraEntity.Id = id;
                OrdenTrabajoCabecera cabecera = await repository.Modificar(cabeceraEntity);
                cabecera = await repository.ObtenerPorId(cabecera.Id);

                OrdenTrabajoPersonal[] originalesPersonas = cabecera.Personales.ToArray();
                OrdenTrabajoDetalle[] originalesDetalles = cabecera.OrdenTrabajoDetalles.ToArray();
                OrdenTrabajoDetalleActivo[] originalesActivos = originalesDetalles
                    .Select(x => x.OrdenTrabajoDetalleActivo)
                    .ToArray();

                OrdenTrabajoPersonal[] personasActualizadas = command.Personas
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

                OrdenTrabajoMantenimientoExternoDetalleRegistro[] detallesEntrada = command.Detalles.ToArray();
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
                    OrdenTrabajoMantenimientoExternoDetalleActivoRegistro activo = detallesEntrada[i].Activo;
                    var modificarActivoCommand = new OrdenTrabajoDetalleActivoModificarCommand(
                        activo.Id,
                        cabecera.EmpresaId,
                        detalles[i].Id,
                        activo.ActivoId
                    );
                    activosActualizados[i] = mapper.Map<OrdenTrabajoDetalleActivo>(modificarActivoCommand);
                }
                await detalleActivoRepository.FusionarRange(originalesActivos, activosActualizados);

                await unitOfWork.CommitAsync();
                return await repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
