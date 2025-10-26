namespace nest.core.dominio.Legal.ContratoTipoEntities
{
    public interface IContratoTipoRepository
    {
        Task<ContratoTipo> ObtenerPorId(byte id);
        Task<List<ContratoTipo>> ObtenerTodos();
        Task<ContratoTipo> Agregar(ContratoTipo entidad);
        Task<ContratoTipo> Modificar(ContratoTipo entidad);
        Task Eliminar(byte id);
    }
}
