namespace nest.core.dominio.Aplicacion.Formulario
{
    public interface IFormularioRepository
    {
        Task<Formulario> ObtenerPorId(int id);
        Task<List<Formulario>> ObtenerPorModuloId(int moduloId);
        Task<List<Formulario>> ObtenerTodos();
        Task<List<Formulario>> ObtenerPorUnaPropiedad(Dictionary<string, object?> filtros);
        Task<List<Formulario>> ObtenerPorRolId(string roleId);
        Task<List<Formulario>> ObtenerPorUserId(string userId);
        Task<Formulario> Agregar(Formulario entry);
        Task<Formulario> Modificar(Formulario entry);
        Task Eliminar(int id);
    }
}
