using System.Collections.Generic;
using System.Threading.Tasks;

namespace nest.core.dominio.Patrimonial.UbicacionTecnicaEntities
{
    public interface IUbicacionTecnicaRepository
    {
        Task<UbicacionTecnica> ObtenerPorId(long id);
        Task<List<UbicacionTecnica>> ObtenerTodos();
        Task<List<UbicacionTecnica>> ObtenerActivas();
        Task<UbicacionTecnica> Agregar(UbicacionTecnicaCrearDto entry);
        Task<UbicacionTecnica> Modificar(long id, UbicacionTecnicaCrearDto entry);
        Task Eliminar(long id);
    }
}
