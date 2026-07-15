namespace nest.core.dominio.RRHH.TerminalBiometricoEntities
{
    public interface ITerminalBiometricoRepository
    {
        Task<TerminalBiometrico> ObtenerPorId(int id);
        Task<List<TerminalBiometrico>> ObtenerTodos();
        Task<TerminalBiometrico> Agregar(TerminalBiometrico entry);
        Task<TerminalBiometrico> Modificar(TerminalBiometrico entry);
        Task Eliminar(int id);
    }
}
