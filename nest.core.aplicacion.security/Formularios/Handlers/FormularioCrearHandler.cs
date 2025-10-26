using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using nest.core.aplicacion.security.Formularios.Commands;
using nest.core.dominio.Aplicacion.Formulario;

namespace nest.core.aplicacion.security.Formularios.Handlers;

public class FormularioCrearHandler : IRequestHandler<FormularioCrearCommand, Formulario>
{
    private readonly IFormularioRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<FormularioCrearHandler> logger;

    public FormularioCrearHandler(IFormularioRepository repository, IMapper mapper, ILogger<FormularioCrearHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<Formulario> Handle(FormularioCrearCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = mapper.Map<Formulario>(request);
            return await repository.Agregar(entity);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error al crear el formulario {Nombre}", request.Nombre);
            throw;
        }
    }
}
