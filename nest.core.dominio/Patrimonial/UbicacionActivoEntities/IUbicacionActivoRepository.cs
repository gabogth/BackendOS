using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.Patrimonial.UbicacionActivoEntities
{
    public interface IUbicacionActivoRepository
    {
        Task<UbicacionActivo> ObtenerPorId(long id);
        Task<List<UbicacionActivo>> ObtenerTodos();
        Task<List<UbicacionActivo>> ObtenerPorActivo(long activoId);
        Task<UbicacionActivo> Agregar(UbicacionActivoCrearDto entry);
        Task<UbicacionActivo> Modificar(long id, UbicacionActivoCrearDto entry);
        Task Eliminar(long id);
    }
}
