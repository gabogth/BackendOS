using System.Collections.Generic;
using System.Threading.Tasks;
using nest.core.dominio.General.AdjuntoProviderEntities;

namespace nest.core.aplicacion.general.AdjuntoConfigProviderServices
{
    public class AdjuntoConfigProviderService
    {
        private readonly IAdjuntoConfigProviderRepository repository;

        public AdjuntoConfigProviderService(IAdjuntoConfigProviderRepository repository)
        {
            this.repository = repository;
        }

        public Task<AdjuntoConfigProvider> ObtenerPorId(AdjuntoConfigProviderModuloEnum id) => repository.ObtenerPorId(id);
        public Task<List<AdjuntoConfigProvider>> ObtenerTodos() => repository.ObtenerTodos();
        public Task<List<AdjuntoConfigProvider>> ObtenerActivos() => repository.ObtenerActivos();
        public Task<AdjuntoConfigProvider> Agregar(AdjuntoConfigProviderCrearDto entry) => repository.Agregar(entry);
        public Task<AdjuntoConfigProvider> Modificar(AdjuntoConfigProviderModuloEnum id, AdjuntoConfigProviderCrearDto entry) => repository.Modificar(id, entry);
        public Task Eliminar(AdjuntoConfigProviderModuloEnum id) => repository.Eliminar(id);
    }
}
