using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Departamentos.Commands;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Departamentos.Handlers
{
    public class DepartamentoCrearHandler : IRequestHandler<DepartamentoCrearCommand, Departamento>
    {
        private readonly IDepartamentoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DepartamentoCrearHandler> logger;

        public DepartamentoCrearHandler(IDepartamentoRepository repository, IMapper mapper, ILogger<DepartamentoCrearHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Departamento> Handle(DepartamentoCrearCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Departamento>(request);
                return await repository.Agregar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
