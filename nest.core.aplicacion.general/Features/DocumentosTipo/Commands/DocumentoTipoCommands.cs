using MediatR;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.Features.DocumentosTipo.Commands;

public record CreateDocumentoTipoCommand(string Nombre, string NombreCorto, string CodigoEstatal) : IRequest<DocumentoTipo>;

public class CreateDocumentoTipoCommandHandler(IDocumentoTipoRepository repository)
    : IRequestHandler<CreateDocumentoTipoCommand, DocumentoTipo>
{
    public Task<DocumentoTipo> Handle(CreateDocumentoTipoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DocumentoTipoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto,
            CodigoEstatal = request.CodigoEstatal
        };
        return repository.Agregar(dto);
    }
}

public record UpdateDocumentoTipoCommand(int Id, string Nombre, string NombreCorto, string CodigoEstatal) : IRequest<DocumentoTipo>;

public class UpdateDocumentoTipoCommandHandler(IDocumentoTipoRepository repository)
    : IRequestHandler<UpdateDocumentoTipoCommand, DocumentoTipo>
{
    public Task<DocumentoTipo> Handle(UpdateDocumentoTipoCommand request, CancellationToken cancellationToken)
    {
        var dto = new DocumentoTipoCrearDto
        {
            Nombre = request.Nombre,
            NombreCorto = request.NombreCorto,
            CodigoEstatal = request.CodigoEstatal
        };
        return repository.Modificar(request.Id, dto);
    }
}

public record DeleteDocumentoTipoCommand(int Id) : IRequest<Unit>;

public class DeleteDocumentoTipoCommandHandler(IDocumentoTipoRepository repository)
    : IRequestHandler<DeleteDocumentoTipoCommand, Unit>
{
    public async Task<Unit> Handle(DeleteDocumentoTipoCommand request, CancellationToken cancellationToken)
    {
        await repository.Eliminar(request.Id);
        return Unit.Value;
    }
}
