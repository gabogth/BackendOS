using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Commands;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class FormularioModificarHandler : IRequestHandler<FormularioModificarCommand, Formulario>
{
    private readonly IFormularioRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<FormularioModificarHandler> logger;

    public FormularioModificarHandler(IFormularioRepository repository, IMapper mapper, ILogger<FormularioModificarHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Formulario> Handle(FormularioModificarCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Formulario>(request);
            return await repository.Modificar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al modificar el formulario {Id}", request.Id);
            throw;
        }
    }
}
