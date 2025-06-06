namespace nest.core.dominio.Legal.ContratoCabeceraEntities
{
    public interface IContratoCabeceraRepository
    {
        Task<ContratoCabecera> ObtenerPorId(int id);
        Task<List<ContratoCabecera>> ObtenerTodos();
        Task<ContratoCabecera> Agregar(ContratoCrearDto entidad);
        Task Eliminar(int id);
    }
}
