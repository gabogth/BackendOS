using System.Collections.Generic;

namespace nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities
{
    public interface IOrdenTrabajoPersonalRepository
    {
        Task<OrdenTrabajoPersonal> ObtenerPorId(long id);
        Task<List<OrdenTrabajoPersonal>> ObtenerPorIds(List<long> ids);
        Task<List<OrdenTrabajoPersonal>> ObtenerPorCabecera(long ordenTrabajoCabeceraId);
        Task<OrdenTrabajoPersonal> Agregar(OrdenTrabajoPersonalCrearDto dto);
        Task<OrdenTrabajoPersonal[]> AgregarRange(OrdenTrabajoPersonalCrearDto[] dto);
        Task<OrdenTrabajoPersonal> Modificar(long id, OrdenTrabajoPersonalCrearDto dto);
        Task<OrdenTrabajoPersonal[]> ModificarRange((long id, OrdenTrabajoPersonalCrearDto dto)[] dto);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
        Task<OrdenTrabajoPersonal[]> FusionarRange(OrdenTrabajoPersonal[] originalEntities, (long id, OrdenTrabajoPersonalCrearDto dto)[] dto);
    }
}
