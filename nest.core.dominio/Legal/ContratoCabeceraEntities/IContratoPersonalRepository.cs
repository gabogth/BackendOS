namespace nest.core.dominio.Legal.ContratoCabeceraEntities
{
    public interface IContratoPersonalRepository
    {
        Task<ContratoCabecera> ObtenerPorId(long id);
        Task<ContratoCabecera> ObtenerPorContratoTipoIdAndNumero(byte ContratoTipoId, int Numero);
        Task<List<ContratoCabecera>> ObtenerTodos();
        Task<ContratoCabecera> CrearContratoPersonal(ContratoPersonalDto entidad);
        Task<ContratoCabecera> Modificar(long id, ContratoPersonalDto entidad);
        Task Eliminar(long id);
    }
}
