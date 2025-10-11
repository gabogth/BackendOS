namespace nest.core.dominio.Mantto.OrdenTrabajoPersonalEntities
{
    public interface IOrdenTrabajoPersonalRepository
    {
        Task<OrdenTrabajoPersonal> ObtenerPorId(long id);
        Task<List<OrdenTrabajoPersonal>> ObtenerPorCabecera(long ordenTrabajoCabeceraId);
        Task<OrdenTrabajoPersonal> Agregar(OrdenTrabajoPersonalCrearDto dto);
        Task<OrdenTrabajoPersonal> Modificar(long id, OrdenTrabajoPersonalCrearDto dto);
        Task Eliminar(long id);
    }
}
