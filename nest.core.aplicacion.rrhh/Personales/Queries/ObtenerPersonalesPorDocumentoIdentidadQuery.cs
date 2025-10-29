using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.PersonalEntities;

namespace nest.core.aplicacion.rrhh.Personales.Queries;

public record ObtenerPersonalesPorDocumentoIdentidadQuery(
    int tipoDocumentoId, 
    string documentoIdentidad
    ) : IRequest<Personal>, ICommandBase;
