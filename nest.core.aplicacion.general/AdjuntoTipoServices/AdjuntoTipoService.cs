using nest.core.dominio.General.AdjuntoTipoEntities;

namespace nest.core.aplicacion.general.AdjuntoTipoServices
{
    public class AdjuntoTipoService
    {
        private readonly IAdjuntoTipoRepository repository;
        public AdjuntoTipoService(IAdjuntoTipoRepository repository)
        {
            this.repository = repository;
        }

        public Task<AdjuntoTipo> ObtenerPorId(AdjuntoTipoEnum id) => repository.ObtenerPorId(id);
        public Task<List<AdjuntoTipo>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<AdjuntoTipo>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<AdjuntoTipo> Agregar(AdjuntoTipoCrearDto entry) => repository.Agregar(entry);
        public Task<AdjuntoTipo> Modificar(AdjuntoTipoEnum id, AdjuntoTipoCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(AdjuntoTipoEnum id) => repository.Eliminar(id);
    }
}
