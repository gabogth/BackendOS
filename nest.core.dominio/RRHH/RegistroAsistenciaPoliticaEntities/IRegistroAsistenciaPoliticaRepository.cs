namespace nest.core.dominio.RRHH.RegistroAsistenciaPoliticaEntities
{
    public interface IRegistroAsistenciaPoliticaRepository
    {
        Task<RegistroAsistenciaPolitica> ObtenerPorId(long id);
        Task<List<RegistroAsistenciaPolitica>> ObtenerTodos();
        Task<RegistroAsistenciaPolitica> Agregar(RegistroAsistenciaPoliticaCrearDto entidad);
        Task<RegistroAsistenciaPolitica> Modificar(long id, RegistroAsistenciaPoliticaCrearDto entidad);
        Task Eliminar(long id);
    }
}
