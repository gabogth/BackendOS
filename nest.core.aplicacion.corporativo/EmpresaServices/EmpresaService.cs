using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.corporativo.EmpresaServices
{
    public class EmpresaService
    {
        private readonly IEmpresaRepository repository;
        private readonly IUsuarioEmpresaRepository usuarioEmpresaRepository;
        private readonly IConnectionStringService connectionStringService;
        private readonly IUnitOfWork unitOfWork;

        public EmpresaService(IEmpresaRepository repository, IUsuarioEmpresaRepository usuarioEmpresaRepository, IConnectionStringService connectionStringService, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.usuarioEmpresaRepository = usuarioEmpresaRepository;
            this.connectionStringService = connectionStringService;
            this.unitOfWork = unitOfWork;
        }

        public Task<List<Empresa>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Empresa>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Empresa?> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public async Task<Empresa> Agregar(EmpresaCrearDto entry)
        {
            await this.unitOfWork.BeginTransactionAsync();
            try
            {
                Empresa empresa = await repository.Agregar(entry);
                await usuarioEmpresaRepository.Agregar(new UsuarioEmpresaCrearDto
                {
                    Actual = false,
                    EmpresaId = empresa.Id,
                    UsuarioId = connectionStringService.UserId
                });
                await this.unitOfWork.CommitAsync();
                return empresa;
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
        public Task<Empresa> Modificar(int id, EmpresaCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}

