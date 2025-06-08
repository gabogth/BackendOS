using nest.core.dominio.General.SexoEntities;

namespace nest.core.aplicacion.general.SexoServices
{
    public class SexoService
    {
        private readonly ISexoRepository repository;
        public SexoService(ISexoRepository repository)
        {
            this.repository = repository;
        }
        public Task<Sexo> ObtenerPorId(byte id) => repository.ObtenerPorId(id);
        public Task<List<Sexo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<Sexo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<Sexo> Agregar(SexoCrearDto entry) => repository.Agregar(entry);
        public Task<Sexo> Modificar(byte id, SexoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(byte id) => repository.Eliminar(id);
    }
}
