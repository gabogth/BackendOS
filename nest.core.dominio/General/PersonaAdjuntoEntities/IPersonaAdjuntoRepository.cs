using System.Collections.Generic;

namespace nest.core.dominio.General.PersonaAdjuntoEntities
{
    public interface IPersonaAdjuntoRepository
    {
        Task<PersonaAdjunto> ObtenerPorId(long id);
        Task<List<PersonaAdjunto>> ObtenerTodos();
        Task<List<PersonaAdjunto>> ObtenerPorPersona(int personaId);
        Task<PersonaAdjunto> Agregar(PersonaAdjunto entry);
        Task<PersonaAdjunto[]> AgregarRange(PersonaAdjunto[] entries);
        Task<PersonaAdjunto> Modificar(PersonaAdjunto entry);
        Task<PersonaAdjunto[]> FusionarRange(PersonaAdjunto[] originalEntities, PersonaAdjunto[] entries);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
    }
}
