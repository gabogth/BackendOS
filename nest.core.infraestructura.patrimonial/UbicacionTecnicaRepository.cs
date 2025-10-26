using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio.Cache;
using nest.core.dominio.Patrimonial.UbicacionTecnicaEntities;
using nest.core.infraestructura.db.Cache;
using nest.core.infraestructura.db.DbContext;

namespace nest.core.infraestructura.patrimonial
{
    public class UbicacionTecnicaRepository : CachedRepositoryBase<UbicacionTecnica, long>, IUbicacionTecnicaRepository
    {
        public UbicacionTecnicaRepository(NestDbContext context, IMapper mapper, ICacheRepository cache)
            : base(context, mapper, cache)
        {
        }

        protected override IQueryable<UbicacionTecnica> Query()
        {
            return context.Set<UbicacionTecnica>()
                .Include(x => x.Tercero)
                .AsNoTracking();
        }

        public Task<UbicacionTecnica> Agregar(UbicacionTecnica entry) => AddAsync(entry);
        public Task Eliminar(long id) => DeleteAsync(id);
        public Task<UbicacionTecnica> Modificar(UbicacionTecnica entry) => UpdateAsync(entry);
        public async Task<UbicacionTecnica> ObtenerPorId(long id) => await GetByIdAsync(id);
        public async Task<List<UbicacionTecnica>> ObtenerTodos() => await GetAllAsync();
        public async Task<List<UbicacionTecnica>> ObtenerActivas()
        {
            var registros = await GetCachedListAsync();
            return registros.Where(x => x.Activo)
                .OrderBy(x => x.Nombre)
                .ToList();
        }
    }
}
