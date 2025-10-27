using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.Empresas.Commands;
using nest.core.dominio.Corporativo.Empresa;
using nest.core.dominio.Security.Tenant;
using nest.core.dominio.Security.UsuarioEmpresa;
using nest.core.dominio.Transaccional;

namespace nest.core.aplicacion.corporativo.Empresas.Handlers
{
    public class EmpresaCrearHandler : IRequestHandler<EmpresaCrearCommand, Empresa>
    {
        private readonly IEmpresaRepository repository;
        private readonly IUsuarioEmpresaRepository usuarioEmpresaRepository;
        private readonly IConnectionStringService connectionStringService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<EmpresaCrearHandler> logger;

        public EmpresaCrearHandler(
            IEmpresaRepository repository,
            IUsuarioEmpresaRepository usuarioEmpresaRepository,
            IConnectionStringService connectionStringService,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<EmpresaCrearHandler> logger)
        {
            this.repository = repository;
            this.usuarioEmpresaRepository = usuarioEmpresaRepository;
            this.connectionStringService = connectionStringService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Empresa> Handle(EmpresaCrearCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = mapper.Map<Empresa>(request);
                var empresa = await repository.Agregar(entity);
                await usuarioEmpresaRepository.Agregar(new UsuarioEmpresa
                {
                    Actual = false,
                    EmpresaId = empresa.Id,
                    UsuarioId = connectionStringService.UserId
                });
                await unitOfWork.CommitAsync();
                return empresa;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al crear la empresa");
                await unitOfWork.RollbackAsync();
                throw;
            }
            finally
            {
                await unitOfWork.DisposeAsync();
            }
        }
    }
}
