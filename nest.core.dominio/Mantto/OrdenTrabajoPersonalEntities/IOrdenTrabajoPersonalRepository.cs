using System.Collections.Generic;

namespace nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities
{
    public interface IOrdenTrabajoPersonalRepository
    {
        Task<OrdenTrabajoPersonal> ObtenerPorId(long id);
        Task<List<OrdenTrabajoPersonal>> ObtenerPorIds(List<long> ids);
        Task<List<OrdenTrabajoPersonal>> ObtenerPorCabecera(long ordenTrabajoCabeceraId);
        Task<OrdenTrabajoPersonal> Agregar(OrdenTrabajoPersonal entity);
        Task<OrdenTrabajoPersonal[]> AgregarRange(OrdenTrabajoPersonal[] entities);
        Task<OrdenTrabajoPersonal> Modificar(OrdenTrabajoPersonal entity);
        Task<OrdenTrabajoPersonal[]> ModificarRange(OrdenTrabajoPersonal[] entities);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<OrdenTrabajoPersonal[]> FusionarRange(OrdenTrabajoPersonal[] originalEntities, OrdenTrabajoPersonal[] entities);
    }
}
