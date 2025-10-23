namespace nest.core.dominio.General.PersonaAdjuntoEntities
{
    public interface IPersonaAdjuntoRepository
    {
        Task<PersonaAdjunto> ObtenerPorId(long id);
        Task<List<PersonaAdjunto>> ObtenerTodos();
        Task<List<PersonaAdjunto>> ObtenerPorPersona(int personaId);
        Task<PersonaAdjunto> Agregar(PersonaAdjuntoCrearDto entry);
        Task<PersonaAdjunto> Modificar(long id, PersonaAdjuntoCrearDto entry);
        Task Eliminar(long id);
    }
}
