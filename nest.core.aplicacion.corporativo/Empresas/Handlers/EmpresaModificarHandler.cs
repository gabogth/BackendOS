using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.corporativo.Empresas.Commands;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Handlers
{
    public class EmpresaModificarHandler : IRequestHandler<EmpresaModificarCommand, Empresa>
    {
        private readonly IEmpresaRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<EmpresaModificarHandler> logger;

        public EmpresaModificarHandler(IEmpresaRepository repository, IMapper mapper, ILogger<EmpresaModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Empresa> Handle(EmpresaModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Empresa>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al modificar la empresa");
                throw;
            }
        }
    }
}
