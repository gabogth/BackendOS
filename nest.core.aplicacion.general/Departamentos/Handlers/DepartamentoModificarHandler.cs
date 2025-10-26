using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.general.Departamentos.Commands;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Departamentos.Handlers
{
    public class DepartamentoModificarHandler : IRequestHandler<DepartamentoModificarCommand, Departamento>
    {
        private readonly IDepartamentoRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<DepartamentoModificarHandler> logger;

        public DepartamentoModificarHandler(IDepartamentoRepository repository, IMapper mapper, ILogger<DepartamentoModificarHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Departamento> Handle(DepartamentoModificarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = mapper.Map<Departamento>(request);
                return await repository.Modificar(entity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
