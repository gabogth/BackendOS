using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Commands;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class FormularioEliminarHandler : IRequestHandler<FormularioEliminarCommand, Unit>
{
    private readonly IFormularioRepository repository;
    private readonly ILogger<FormularioEliminarHandler> logger;

    public FormularioEliminarHandler(IFormularioRepository repository, ILogger<FormularioEliminarHandler> logger)
    {
        this.repository = repository;
        this.logger = logger;
    }

    public async Task<Unit> Handle(FormularioEliminarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await repository.Eliminar(request.Id);
            return Unit.Value;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al eliminar el formulario {Id}", request.Id);
            throw;
        }
    }
}
