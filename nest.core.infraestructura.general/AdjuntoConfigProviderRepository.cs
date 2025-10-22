using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using nest.core.dominio.General.AdjuntoProviderEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infrastructura.utils.Excepciones;

namespace nest.core.infraestructura.general
{
    public class AdjuntoConfigProviderRepository : CachedRepositoryBase<AdjuntoConfigProvider, AdjuntoConfigProviderCrearDto, AdjuntoConfigProviderModuloEnum>, IAdjuntoConfigProviderRepository
    {
        public AdjuntoConfigProviderRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache)
        {
        }

        public async Task<AdjuntoConfigProvider> ObtenerPorId(AdjuntoConfigProviderModuloEnum id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
                throw new RegistroNoEncontradoException<AdjuntoConfigProvider>(id.ToString());
            return entity;
        }

        public Task<List<AdjuntoConfigProvider>> ObtenerTodos() => GetAllAsync();

        public async Task<List<AdjuntoConfigProvider>> ObtenerActivos()
        {
            var data = await GetCachedListAsync();
            return data.Where(item => item.Activo).ToList();
        }

        public Task<AdjuntoConfigProvider> Agregar(AdjuntoConfigProviderCrearDto entry) => AddAsync(entry);
        public Task<AdjuntoConfigProvider> Modificar(AdjuntoConfigProviderModuloEnum id, AdjuntoConfigProviderCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(AdjuntoConfigProviderModuloEnum id) => DeleteAsync(id);
    }
}
