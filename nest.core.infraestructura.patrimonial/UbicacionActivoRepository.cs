using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Patrimonial.UbicacionActivoEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.patrimonial
{
    public class UbicacionActivoRepository : CachedRepositoryBase<UbicacionActivo, long>, IUbicacionActivoRepository
    {
        public UbicacionActivoRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache)
        {
        }

        protected override IQueryable<UbicacionActivo> Query()
        {
            return context.Set<UbicacionActivo>()
                .Include(x => x.Activo)
                .Include(x => x.UbicacionTecnica)
                .Include(x => x.ContratoCabecera)
                .AsNoTracking();
        }

        public Task<UbicacionActivo> Agregar(UbicacionActivo entry) => AddAsync(entry);
        public Task Eliminar(long id) => DeleteAsync(id);
        public Task<UbicacionActivo> Modificar(UbicacionActivo entry) => UpdateAsync(entry);
        public async Task<UbicacionActivo> ObtenerPorId(long id) => await GetByIdAsync(id);
        public async Task<List<UbicacionActivo>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<UbicacionActivo>> ObtenerPorActivo(long activoId)
        {
            var registros = await GetCachedListAsync();
            return registros.Where(x => x.ActivoId == activoId)
                .OrderByDescending(x => x.FechaIngreso)
                .ToList();
        }
    }
}
