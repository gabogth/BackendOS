using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class AdjuntoConfigProviderRepository : CachedRepositoryBase<AdjuntoConfigProvider, AdjuntoConfigProviderModuloEnum>, IAdjuntoConfigProviderRepository
    {
        public AdjuntoConfigProviderRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache)
        {
        }

        public Task<AdjuntoConfigProvider> ObtenerPorId(AdjuntoConfigProviderModuloEnum id) => GetByIdAsync(id);

        public Task<List<AdjuntoConfigProvider>> ObtenerTodos() => GetAllAsync();

        public async Task<List<AdjuntoConfigProvider>> ObtenerActivos()
        {
            var data = await GetCachedListAsync();
            return data.Where(item => item.Activo).ToList();
        }

        public Task<AdjuntoConfigProvider> Agregar(AdjuntoConfigProvider entry) => AddAsync(entry);
        public Task<AdjuntoConfigProvider> Modificar(AdjuntoConfigProvider entry) => UpdateAsync(entry);
        public Task Eliminar(AdjuntoConfigProviderModuloEnum id) => DeleteAsync(id);
    }
}
