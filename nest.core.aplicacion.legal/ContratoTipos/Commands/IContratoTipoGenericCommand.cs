using nest.core.aplicacion.utils.Commands;
using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.ContratoTipos.Commands
{
    public interface IContratoTipoGenericCommand : ICommandBase
    {
        string Nombre { get; }
        string Detalle { get; }
    }
}
