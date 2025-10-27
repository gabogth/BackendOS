using MediatR;
using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Finanzas.MonedaEntities;

namespace nest.core.aplicacion.finanzas.Moneda.Commands
{
    public sealed record MonedaCrearCommand(
        string Nombre,
        string NombreCorto,
        string Prefix,
        string Sufix,
        string Simbolo
    ) : IRequest<Moneda>, IMonedaGenericCommand;
}
