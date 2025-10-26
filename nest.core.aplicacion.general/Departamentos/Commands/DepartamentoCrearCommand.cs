using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.General.DepartamentoEntites;

namespace nest.core.aplicacion.general.Departamentos.Commands
{
    public sealed record DepartamentoCrearCommand(
        string Nombre,
        int PaisId
    ) : IRequest<Departamento>, ICommandBase;
}
