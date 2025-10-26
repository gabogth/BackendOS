using AutoMapper;
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

        public OrdenTrabajoMantenimientoExternoService(
            IOrdenTrabajoCabecera_MantenimientoExternoRepository repository,
            IOrdenTrabajoDetalleRepository detalleRepository,
            IOrdenTrabajoDetalleActivoRepository detalleActivoRepository,
            IOrdenTrabajoPersonalRepository ordenTrabajoPersonalRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.repository = repository;
            this.detalleRepository = detalleRepository;
            this.detalleActivoRepository = detalleActivoRepository;
            this.ordenTrabajoPersonalRepository = ordenTrabajoPersonalRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<OrdenTrabajoCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenTrabajoCabecera>> ObtenerTodos() => repository.ObtenerTodos();

        public Task<List<OrdenTrabajoCabecera>> ObtenerPorOrdenServicio(long ordenServicioCabeceraId) => repository.ObtenerPorOrdenServicio(ordenServicioCabeceraId);

        public async Task<OrdenTrabajoCabecera> Agregar(OrdenTrabajoCabecera_MantenimientoExternoCrearDto dto)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenTrabajoCabecera cabeceraEntity = mapper.Map<OrdenTrabajoCabecera>(dto.Cabecera);
                OrdenTrabajoCabecera cabecera = await repository.Agregar(cabeceraEntity);
                List<OrdenTrabajoDetalle_MantenimientoExternoCrearDto> detallesEntrada = dto.Detalles;

                OrdenTrabajoPersonalCrearDto[] personasDtoArray = dto.Personas.ToArray();
                for (int i = 0; i < personasDtoArray.Length; i++)
                {
                    personasDtoArray[i].EmpresaId = cabecera.EmpresaId;
                    personasDtoArray[i].OrdenTrabajoCabeceraId = cabecera.Id;
                }
                await ordenTrabajoPersonalRepository.AgregarRange(personasDtoArray);

                OrdenTrabajoDetalleCrearDto[] detallesDtoArray = new OrdenTrabajoDetalleCrearDto[detallesEntrada.Count];
                for (int i = 0; i < detallesEntrada.Count; i++)
                {
                    OrdenTrabajoDetalleCrearDto currentDetalle = detallesEntrada[i].Detalle;
                    currentDetalle.EmpresaId = cabecera.EmpresaId;
                    currentDetalle.OrdenTrabajoCabeceraId = cabecera.Id;
                    detallesDtoArray[i] = currentDetalle;
                }

                OrdenTrabajoDetalle[] detalles = await detalleRepository.AgregarRange(detallesDtoArray);
                OrdenTrabajoDetalleActivoCrearDto[] activosCrear = new OrdenTrabajoDetalleActivoCrearDto[detallesEntrada.Count];
                for (int i = 0; i < detallesEntrada.Count; i++)
                {
                    OrdenTrabajoDetalleActivoCrearDto activo = detallesEntrada[i].Activo;
                    activo.EmpresaId = cabecera.EmpresaId;
                    activo.OrdenTrabajoDetalleId = detalles[i].Id;
                    activosCrear[i] = activo;
                        
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

        public async Task<OrdenTrabajoCabecera> Modificar(long id, OrdenTrabajoCabecera_MantenimientoExternoCrearDto dto)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenTrabajoCabecera cabeceraEntity = mapper.Map<OrdenTrabajoCabecera>(dto.Cabecera);
                cabeceraEntity.Id = id;
                OrdenTrabajoCabecera cabecera = await repository.Modificar(cabeceraEntity);
                cabecera = await repository.ObtenerPorId(cabecera.Id);

                OrdenTrabajoPersonal[] originalesPersonas = cabecera.Personales.ToArray();
                OrdenTrabajoDetalle[] originalesDetalles = cabecera.OrdenTrabajoDetalles.ToArray();
                OrdenTrabajoDetalleActivo[] originalesActivos = originalesDetalles
                    .Select(x => x.OrdenTrabajoDetalleActivo)
                    .ToArray();

                OrdenTrabajoPersonalCrearDto[] personasEntrada = dto.Personas.ToArray();
                (long id, OrdenTrabajoPersonalCrearDto entry)[] personasConIdDto = new (long, OrdenTrabajoPersonalCrearDto)[dto.Personas.Count];
                for (int i = 0; i < personasConIdDto.Length; i++)
                {
                    OrdenTrabajoPersonalCrearDto currentPersona = personasEntrada[i];
                    currentPersona.EmpresaId = cabecera.EmpresaId;
                    currentPersona.OrdenTrabajoCabeceraId = cabecera.Id;
                    personasConIdDto[i] = (currentPersona.Id, currentPersona);
                }
                await ordenTrabajoPersonalRepository.FusionarRange(originalesPersonas, personasConIdDto);

                OrdenTrabajoDetalle_MantenimientoExternoCrearDto[] detallesEntrada = dto.Detalles.ToArray();
                (long id, OrdenTrabajoDetalleCrearDto entry)[] detallesConIdDto = new (long, OrdenTrabajoDetalleCrearDto)[detallesEntrada.Length];
                for (int i = 0; i < detallesEntrada.Length; i++)
                {
                    OrdenTrabajoDetalleCrearDto currentDetalle = detallesEntrada[i].Detalle;
                    currentDetalle.EmpresaId = cabecera.EmpresaId;
                    currentDetalle.OrdenTrabajoCabeceraId = cabecera.Id;
                    detallesConIdDto[i] = (currentDetalle.Id, currentDetalle);
                }
                OrdenTrabajoDetalle[] detalles = await detalleRepository.FusionarRange(originalesDetalles, detallesConIdDto);

                (long id, OrdenTrabajoDetalleActivoCrearDto entry)[] activosEntries = new (long, OrdenTrabajoDetalleActivoCrearDto)[detallesEntrada.Length];
                for (int i = 0; i < detallesEntrada.Length; i++)
                {
                    OrdenTrabajoDetalleActivoCrearDto activo = detallesEntrada[i].Activo;
                    activo.EmpresaId = cabecera.EmpresaId;
                    activo.OrdenTrabajoDetalleId = detalles[i].Id;
                    activosEntries[i] = (activo.Id, activo);
                }
                await detalleActivoRepository.FusionarRange(originalesActivos, activosEntries.ToArray());

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
