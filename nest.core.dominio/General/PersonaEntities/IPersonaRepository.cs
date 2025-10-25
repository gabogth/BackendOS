namespace nest.core.dominio.General.PersonaEntities
{
    public interface IPersonaRepository
    {
        Task<Persona> ObtenerPorId(int id);
        Task<List<Persona>> ObtenerTodos();
        Task<List<Persona>> ObtenerActivos();
        Task<Persona> Agregar(Persona entidad);
        Task<Persona> Modificar(Persona entidad);
        Task Eliminar(int id);
    }
}
