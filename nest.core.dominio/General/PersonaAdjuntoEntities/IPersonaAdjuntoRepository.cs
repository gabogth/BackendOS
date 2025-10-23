using System.Collections.Generic;

namespace nest.core.dominio.General.PersonaAdjuntoEntities
{
    public interface IPersonaAdjuntoRepository
    {
        Task<PersonaAdjunto> ObtenerPorId(long id);
        Task<List<PersonaAdjunto>> ObtenerTodos();
        Task<List<PersonaAdjunto>> ObtenerPorPersona(int personaId);
        Task<PersonaAdjunto> Agregar(PersonaAdjuntoCrearDto entry);
        Task<PersonaAdjunto[]> AgregarRange(PersonaAdjuntoCrearDto[] entries);
        Task<PersonaAdjunto> Modificar(long id, PersonaAdjuntoCrearDto entry);
        Task<PersonaAdjunto[]> FusionarRange(PersonaAdjunto[] originalEntities, (long id, PersonaAdjuntoCrearDto entry)[] entries);
        Task Eliminar(long id);
        Task EliminarRange(long[] ids);
    }
}
