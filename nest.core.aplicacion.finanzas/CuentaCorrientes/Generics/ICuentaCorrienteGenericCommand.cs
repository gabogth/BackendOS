namespace nest.core.aplicacion.finanzas.CuentaCorrientes.Interfaces
{
    public interface ICuentaCorrienteGenericCommand
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
