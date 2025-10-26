using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.Patrimonial.UbicacionTecnicaEntities
{
    public interface IUbicacionTecnicaRepository
    {
        Task<UbicacionTecnica> ObtenerPorId(long id);
        Task<List<UbicacionTecnica>> ObtenerTodos();
        Task<List<UbicacionTecnica>> ObtenerActivas();
        Task<UbicacionTecnica> Agregar(UbicacionTecnica entry);
        Task<UbicacionTecnica> Modificar(UbicacionTecnica entry);
        Task Eliminar(long id);
    }
}
