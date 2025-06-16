namespace nest.core.dominio.RRHH.PersonalEstadoEntities
{
    public interface IPersonalEstadoRepository
    {
        Task<PersonalEstado> ObtenerPorId(byte id);
        Task<List<PersonalEstado>> ObtenerTodos();
        Task<List<PersonalEstado>> ObtenerActivos();
        Task<PersonalEstado> Agregar(PersonalEstadoCrearDto entidad);
        Task<PersonalEstado> Modificar(byte id, PersonalEstadoCrearDto entidad);
        Task Eliminar(byte id);
    }
}
