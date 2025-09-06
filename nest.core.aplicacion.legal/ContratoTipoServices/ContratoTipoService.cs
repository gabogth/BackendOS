using nest.core.dominio.Legal.ContratoTipoEntities;

namespace nest.core.aplicacion.legal.ContratoTipoServices
{
    public class ContratoTipoService
    {
        private readonly IContratoTipoRepository repository;
        public ContratoTipoService(IContratoTipoRepository repository)
        {
            this.repository = repository;
        }

        public Task<ContratoTipo> ObtenerPorId(byte id) => this.repository.ObtenerPorId(id);
        public Task<List<ContratoTipo>> ObtenerTodos() => this.repository.ObtenerTodos();
        public Task<ContratoTipo> Agregar(ContratoTipoCrearDto entry) => this.repository.Agregar(entry);
        public Task<ContratoTipo> Modificar(byte id, ContratoTipoCrearDto entry) => this.repository.Modificar(id, entry);
        public Task Eliminar(byte id) => this.repository.Eliminar(id);
    }
}
