using nest.core.dominio.Legal.ContratoCabeceraEntities;


namespace nest.core.aplicacion.legal.ContratoServices
{
    public class ContratoPersonalService
    {
        private readonly IContratoPersonalRepository repository;

        public ContratoPersonalService(IContratoPersonalRepository repository)
        {
            this.repository = repository;
        }

        public Task<ContratoCabecera> ObtenerPorId(int id) => repository.ObtenerPorId(id);
        public Task<List<ContratoCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<ContratoCabecera> CrearContratoPersonal(ContratoPersonalDto entry) =>
            repository.CrearContratoPersonal(entry);
        public Task Eliminar(int id) => repository.Eliminar(id);
    }
}
