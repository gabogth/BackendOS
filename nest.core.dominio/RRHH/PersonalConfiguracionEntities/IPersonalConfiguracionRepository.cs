namespace nest.core.dominio.RRHH.PersonalConfiguracionEntities
{
    public interface IPersonalConfiguracionRepository
    {
        Task<PersonalConfiguracion> ObtenerPorId(int id);
        Task<List<PersonalConfiguracion>> ObtenerTodos();
        Task<List<PersonalConfiguracion>> ObtenerActivos();
        Task<PersonalConfiguracion> Agregar(PersonalConfiguracionCrearDto entry);
        Task<PersonalConfiguracion> Modificar(int id, PersonalConfiguracionCrearDto entry);
        Task Eliminar(int id);
    }
}
