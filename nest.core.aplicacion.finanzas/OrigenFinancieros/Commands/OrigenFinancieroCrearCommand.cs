using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.OrigenFinancieroEntities;

namespace nest.core.aplicacion.finanzas.OrigenFinancieros.Commands
{
    public sealed record OrigenFinancieroCrearCommand(
        string Nombre,
        string NombreCorto,
        string Naturaleza,
        bool Activo
    ) : IRequest<OrigenFinanciero>, ICommandBase;
}
