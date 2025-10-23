using MediatR;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.Features.DocumentosIdentidadTipo.Commands;

public record CreateDocumentoIdentidadTipoCommand(string Nombre, string NombreCorto) : IRequest<DocumentoIdentidadTipo>;

public class CreateDocumentoIdentidadTipoCommandHandler(IDocumentoIdentidadTipoRepository repository)
    : IRequestHandler<CreateDocumentoIdentidadTipoCommand, DocumentoIdentidadTipo>
{
    public Task<DocumentoIdentidadTipo> Handle(CreateDocumentoIdentidadTipoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DocumentoIdentidadTipoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto
        };
        return repository.Agregar(dto);
    }
}

public record UpdateDocumentoIdentidadTipoCommand(byte Id, string Nombre, string NombreCorto) : IRequest<DocumentoIdentidadTipo>;

public class UpdateDocumentoIdentidadTipoCommandHandler(IDocumentoIdentidadTipoRepository repository)
    : IRequestHandler<UpdateDocumentoIdentidadTipoCommand, DocumentoIdentidadTipo>
{
    public Task<DocumentoIdentidadTipo> Handle(UpdateDocumentoIdentidadTipoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DocumentoIdentidadTipoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteDocumentoIdentidadTipoCommand(byte Id) : IRequest<Unit>;

public class DeleteDocumentoIdentidadTipoCommandHandler(IDocumentoIdentidadTipoRepository repository)
    : IRequestHandler<DeleteDocumentoIdentidadTipoCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDocumentoIdentidadTipoCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
