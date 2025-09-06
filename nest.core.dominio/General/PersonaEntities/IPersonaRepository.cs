namespace nest.core.dominio.General.PersonaEntities
{
    public interface IPersonaRepository
    {
        Task<Persona> ObtenerPorId(int id);
        Task<List<Persona>> ObtenerTodos();
        Task<List<Persona>> ObtenerActivos();
        Task<Persona> Agregar(PersonaCrearDto entidad);
        Task<Persona> Modificar(int id, PersonaCrearDto entidad);
        Task Eliminar(int id);
    }
}
