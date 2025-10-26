namespace nest.core.dominio.General.AdjuntoEntities
{
    public interface IAdjuntoRepository
    {
        Task<Adjunto> ObtenerPorId(long id);
        Task<List<Adjunto>> ObtenerTodos();
        Task<Adjunto> Agregar(Adjunto entry);
        Task<Adjunto> Modificar(Adjunto entry);
        Task Eliminar(long id);
    }
}
