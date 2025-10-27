using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Mantto.LaborEntities;

namespace nest.core.aplicacion.mantto.Labores.Commands
{
    public sealed record LaborCrearCommand(
        string Nombre,
        string NombreCorto,
        bool Activo
    ) : IRequest<Labor>, ILaborGenericCommand;
}
