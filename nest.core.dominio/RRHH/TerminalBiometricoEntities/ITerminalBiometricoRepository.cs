using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.TerminalBiometricoEntities
{
    public interface ITerminalBiometricoRepository
    {
        Task<TerminalBiometrico> ObtenerPorId(int id);
        Task<List<TerminalBiometrico>> ObtenerTodos();
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<TerminalBiometrico> Agregar(TerminalBiometrico entry);
        Task<TerminalBiometrico> Modificar(TerminalBiometrico entry);
        Task Eliminar(int id);
    }
}
