namespace nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities
{
    public interface IRegistroAsistenciaPoliticaRepository
    {
        Task<RegistroAsistenciaPolitica> ObtenerPorId(long id);
        Task<List<RegistroAsistenciaPolitica>> ObtenerTodos();
        Task<RegistroAsistenciaPolitica> Agregar(RegistroAsistenciaPolitica entry);
        Task<RegistroAsistenciaPolitica> Modificar(RegistroAsistenciaPolitica entry);
        Task Eliminar(long id);
    }
}
