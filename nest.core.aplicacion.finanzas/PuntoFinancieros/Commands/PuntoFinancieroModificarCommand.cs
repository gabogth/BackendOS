using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.PuntoFinancieroEntities;

namespace nest.core.aplicacion.finanzas.PuntoFinancieros.Commands
{
    public sealed record PuntoFinancieroModificarCommand(
        int Id,
        int EmpresaId,
        string Nombre,
        string NombreCorto,
        bool Activo
    ) : IRequest<PuntoFinanciero>, IPuntoFinancieroGenericCommand;
}
