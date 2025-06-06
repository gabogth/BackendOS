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

        public Task<ContratoCabecera> ObtenerPorId(long id) => repository.ObtenerPorId(id);
        public Task<ContratoCabecera> ObtenerPorId(byte contratoTipoId, int numero) => repository.ObtenerPorContratoTipoIdAndNumero(contratoTipoId, numero);
        public Task<List<ContratoCabecera>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<ContratoCabecera> CrearContratoPersonal(ContratoPersonalDto entry) =>
            repository.CrearContratoPersonal(entry);
        public Task Eliminar(long id) => repository.Eliminar(id);
    }
}
