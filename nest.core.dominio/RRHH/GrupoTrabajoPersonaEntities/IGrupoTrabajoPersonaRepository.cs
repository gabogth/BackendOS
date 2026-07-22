using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.GrupoTrabajoPersonaEntities
{
    public interface IGrupoTrabajoPersonaRepository
    {
        Task<GrupoTrabajoPersona> ObtenerPorId(long id);
        Task<List<GrupoTrabajoPersona>> ObtenerTodos();
        Task<List<GrupoTrabajoPersona>> ObtenerPorGrupoTrabajo(long grupoTrabajoId);
        Task<GrupoTrabajoPersona> Agregar(GrupoTrabajoPersona entry);
        Task<GrupoTrabajoPersona[]> AgregarRange(GrupoTrabajoPersona[] entries);
        Task<GrupoTrabajoPersona> Modificar(GrupoTrabajoPersona entry);
        Task<GrupoTrabajoPersona[]> ModificarRange(GrupoTrabajoPersona[] entries);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<GrupoTrabajoPersona[]> FusionarRange(GrupoTrabajoPersona[] original, GrupoTrabajoPersona[] entries);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
    }
}
