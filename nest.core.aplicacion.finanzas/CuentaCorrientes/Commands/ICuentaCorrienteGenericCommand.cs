using nest.core.aplicacion.utils.Commands;

namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Commands
{
    public interface ICuentaCorrienteGenericCommand : ICommandBase
    {
        int EmpresaId { get; }
        string Nombre { get; }
        string NombreCorto { get; }
        bool Activo { get; }
        string CuentaNumero { get; }
        int EntidadFinancieraId { get; }
        long CuentaContableId { get; }
    }
}
