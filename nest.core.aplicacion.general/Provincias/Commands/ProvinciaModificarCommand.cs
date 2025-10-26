using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.ProvinciaEntities;

namespace nest.core.aplicacion.general.Provincias.Commands
{
    public sealed record ProvinciaModificarCommand(
        int Id,
        string Nombre,
        int DepartamentoId
    ) : IRequest<Provincia>, ICommandBase;
}
