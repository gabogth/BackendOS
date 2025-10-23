using MediatR;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.Features.DocumentosIdentidadTipo.Queries;

public record GetDocumentosIdentidadTipoQuery() : IRequest<List<DocumentoIdentidadTipo>>;

public class GetDocumentosIdentidadTipoQueryHandler(IDocumentoIdentidadTipoRepository repository)
    : IRequestHandler<GetDocumentosIdentidadTipoQuery, List<DocumentoIdentidadTipo>>
{
    public Task<List<DocumentoIdentidadTipo>> Handle(GetDocumentosIdentidadTipoQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetDocumentoIdentidadTipoByIdQuery(byte Id) : IRequest<DocumentoIdentidadTipo>;

public class GetDocumentoIdentidadTipoByIdQueryHandler(IDocumentoIdentidadTipoRepository repository)
    : IRequestHandler<GetDocumentoIdentidadTipoByIdQuery, DocumentoIdentidadTipo>
{
    public Task<DocumentoIdentidadTipo> Handle(GetDocumentoIdentidadTipoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetDocumentosIdentidadTipoActivosQuery() : IRequest<List<DocumentoIdentidadTipo>>;

public class GetDocumentosIdentidadTipoActivosQueryHandler(IDocumentoIdentidadTipoRepository repository)
    : IRequestHandler<GetDocumentosIdentidadTipoActivosQuery, List<DocumentoIdentidadTipo>>
{
    public Task<List<DocumentoIdentidadTipo>> Handle(GetDocumentosIdentidadTipoActivosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
