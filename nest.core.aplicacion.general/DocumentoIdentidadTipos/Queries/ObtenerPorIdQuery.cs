using MediatR;
using nest.core.aplicacion.utils.Queries;
using nest.core.dominio.General.DocumentoIdentidadTipoEntities;

namespace nest.core.aplicacion.general.DocumentoIdentidadTipos.Queries
{
    public sealed record ObtenerPorIdQuery(
        byte Id
    ) : IRequest<DocumentoIdentidadTipo>, IQueryBase;
}
