using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using nest.core.dominio.Cache;
using nest.core.dominio.General.AdjuntoTipoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.general
{
    public class AdjuntoTipoRepository : CachedRepositoryBase<AdjuntoTipo, AdjuntoTipoCrearDto, AdjuntoTipoEnum>, IAdjuntoTipoRepository
    {
        public AdjuntoTipoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache) : base(context, mapper, cache)
        {
        }

        public async Task<AdjuntoTipo> ObtenerPorId(AdjuntoTipoEnum id) => await GetByIdAsync(id);
        public async Task<List<AdjuntoTipo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<AdjuntoTipo>> ObtenerActivos() =>
            (await GetCachedListAsync()).Where(x => x.Activo).ToList();
        public Task<AdjuntoTipo> Agregar(AdjuntoTipoCrearDto entry) => AddAsync(entry);
        public Task<AdjuntoTipo> Modificar(AdjuntoTipoEnum id, AdjuntoTipoCrearDto entry) => UpdateAsync(id, entry);
        public Task Eliminar(AdjuntoTipoEnum id) => DeleteAsync(id);
    }
}
