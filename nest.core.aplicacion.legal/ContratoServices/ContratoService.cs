using nest.core.dominio.Legal.ContratoCabeceraEntities;

namespace nest.core.aplicacion.legal.ContratoServices
{
    public class ContratoService
    {
        private readonly IContratoCabeceraRepository repository;

        public ContratoService(IContratoCabeceraRepository repository)
        {
            this.repository = repository;
        }

        public Task<ContratoCabecera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<ContratoCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<ContratoCabecera> Agregar(ContratoCrearDto entry) => repository.Agregar(entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
