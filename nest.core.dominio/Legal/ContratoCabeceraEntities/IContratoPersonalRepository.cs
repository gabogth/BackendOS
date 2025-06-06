namespace nest.core.dominio.Legal.ContratoCabeceraEntities
{
    public interface IContratoPersonalRepository
    {
        Task<ContratoCabecera> ObtenerPorId(int id);
        Task<List<ContratoCabecera>> ObtenerTodos();
        Task<ContratoCabecera> CrearContratoPersonal(ContratoPersonalDto entidad);
        Task Eliminar(int id);
    }
}
