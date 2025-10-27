using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Corporativo.Empresa;

namespace nest.core.aplicacion.corporativo.Empresas.Commands
{
    public sealed record EmpresaCrearCommand(
        string Nombre,
        string NombreCorto,
        bool Estado
    ) : IRequest<Empresa>, IEmpresaGenericCommand;
}
