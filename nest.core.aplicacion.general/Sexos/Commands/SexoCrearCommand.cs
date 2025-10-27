using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.Sexos.Commands
{
    public sealed record SexoCrearCommand(
        string Nombre,
        string NombreCorto
    ) : IRequest<Sexo>, ISexoGenericCommand;
}
