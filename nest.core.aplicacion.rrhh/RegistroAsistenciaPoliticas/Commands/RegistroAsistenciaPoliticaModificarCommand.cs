using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities;

namespace nest.core.aplicacion.rrhh.RegistroAsistenciaPoliticas.Commands;

public record RegistroAsistenciaPoliticaModificarCommand(
    long Id,
    int EmpresaId,
    string Nombre,
    string NombreCorto,
    string Descripcion,
    int MinutosTardanzaIngreso,
    int MinutosExtra,
    int MinutosExtraEntrada,
    bool TieneCompletarHora
) : IRequest<RegistroAsistenciaPolitica>, IRegistroAsistenciaPoliticaGenericCommand;
