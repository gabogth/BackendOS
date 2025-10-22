namespace nest.core.dominio.General.AdjuntoEntities
{
    public interface IAdjuntoRepository
    {
        Task<Adjunto> ObtenerPorId(long id);
        Task<List<Adjunto>> ObtenerTodos();
        Task<Adjunto> Agregar(AdjuntoCrearDto entry);
        Task<Adjunto> Modificar(long id, AdjuntoCrearDto entry);
        Task Eliminar(long id);
    }
}
