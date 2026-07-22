using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;

namespace nest.core.dominio.RRHH.HorarioCabeceraEntities
{
    public interface IHorarioRepository
    {
        Task<HorarioCabecera> ObtenerPorId(int id);
        Task<List<HorarioCabecera>> ObtenerTodos();
        Task<HorarioCabecera> Agregar(HorarioCabecera entidad);
        Task<HorarioCabecera> Modificar(HorarioCabecera entidad);
        Task Eliminar(int id);
        Task<HorarioCabecera> ObtenerPorPersonalId(int personalId);
        Task<LoadResult> ObtenerFilter(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
        Task<LoadResult> ObtenerFilterActivos(DataSourceLoadOptionsBase options, CancellationToken cancellationToken);
    }
}
