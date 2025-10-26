using AutoMapper;
using nest.core.dominio.Mantto.OrdenServicioCabeceraEntities;
using nest.core.dominio.Mantto.OrdenServicioMantenimientoExternoEntities;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.mantto.OrdenServicio
{
    public class MantenimientoExternoService
    {
        private readonly IOrdenServicioCabecera_MantenimientoExternoRepository repository;
        private readonly IOrdenServicioMantenimientoExternoRepository ordenServicioMantenimientoExternoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public MantenimientoExternoService(IOrdenServicioCabecera_MantenimientoExternoRepository repository, IOrdenServicioMantenimientoExternoRepository ordenServicioMantenimientoExternoRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.ordenServicioMantenimientoExternoRepository = ordenServicioMantenimientoExternoRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public Task<OrdenServicioCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);

        public Task<List<OrdenServicioCabecera>> ObtenerTodos() => repository.ObtenerTodos();

        public async Task<OrdenServicioCabecera> Agregar(OrdenServicioCabecera_MantenimientoExternoCrearDto dto)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenServicioCabecera cabeceraEntity = mapper.Map<OrdenServicioCabecera>(dto.Cabecera);
                OrdenServicioCabecera cabecera = await this.repository.Agregar(cabeceraEntity);
                OrdenServicioMantenimientoExterno externoEntity = mapper.Map<OrdenServicioMantenimientoExterno>(dto.Externo);
                externoEntity.Id = cabecera.Id;
                OrdenServicioMantenimientoExterno externo = await this.ordenServicioMantenimientoExternoRepository.Agregar(externoEntity);
                await this.unitOfWork.CommitAsync();
                return await this.repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }

        public async Task<OrdenServicioCabecera> Modificar(long id, OrdenServicioCabecera_MantenimientoExternoCrearDto dto)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                OrdenServicioCabecera cabeceraEntity = mapper.Map<OrdenServicioCabecera>(dto.Cabecera);
                cabeceraEntity.Id = id;
                OrdenServicioCabecera cabecera = await this.repository.Modificar(cabeceraEntity);
                OrdenServicioMantenimientoExterno externoEntity = mapper.Map<OrdenServicioMantenimientoExterno>(dto.Externo);
                externoEntity.Id = id;
                OrdenServicioMantenimientoExterno externo = await this.ordenServicioMantenimientoExternoRepository.Modificar(externoEntity);
                await this.unitOfWork.CommitAsync();
                return await this.repository.ObtenerPorId(cabecera.Id);
            }
            catch (Exception)
            {
                await this.unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await this.unitOfWork.DisposeAsync();
            }
        }

        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
