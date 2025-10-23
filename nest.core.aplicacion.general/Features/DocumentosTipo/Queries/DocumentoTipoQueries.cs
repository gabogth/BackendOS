using MediatR;
using nest.core.dominio.General.DocumentoTipoEntities;

namespace nest.core.aplicacion.general.Features.DocumentosTipo.Queries;

public record GetDocumentosTipoQuery() : IRequest<List<DocumentoTipo>>;

public class GetDocumentosTipoQueryHandler(IDocumentoTipoRepository repository)
    : IRequestHandler<GetDocumentosTipoQuery, List<DocumentoTipo>>
{
    public Task<List<DocumentoTipo>> Handle(GetDocumentosTipoQuery request, CancellationToken cancellationToken)
        => repository.ObtenerTodos();
}

public record GetDocumentoTipoByIdQuery(int Id) : IRequest<DocumentoTipo>;

public class GetDocumentoTipoByIdQueryHandler(IDocumentoTipoRepository repository)
    : IRequestHandler<GetDocumentoTipoByIdQuery, DocumentoTipo>
{
    public Task<DocumentoTipo> Handle(GetDocumentoTipoByIdQuery request, CancellationToken cancellationToken)
        => repository.ObtenerPorId(request.Id);
}

public record GetDocumentosTipoActivosQuery() : IRequest<List<DocumentoTipo>>;

public class GetDocumentosTipoActivosQueryHandler(IDocumentoTipoRepository repository)
    : IRequestHandler<GetDocumentosTipoActivosQuery, List<DocumentoTipo>>
{
    public Task<List<DocumentoTipo>> Handle(GetDocumentosTipoActivosQuery request, CancellationToken cancellationToken)
        => repository.ObtenerActivos();
}
