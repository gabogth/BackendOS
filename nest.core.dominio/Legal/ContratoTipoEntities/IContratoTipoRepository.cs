namespace nest.core.dominio.Legal.ContratoTipoEntities
{
    public interface IContratoTipoRepository
    {
        Task<ContratoTipo> ObtenerPorId(byte id);
        Task<List<ContratoTipo>> ObtenerTodos();
        Task<ContratoTipo> Agregar(ContratoTipoCrearDto entidad);
        Task<ContratoTipo> Modificar(byte id, ContratoTipoCrearDto entidad);
        Task Eliminar(byte id);
    }
}
