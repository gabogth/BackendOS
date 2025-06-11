using Microsoft.EntityFrameworkCore;
using nest.core.infraestructura.db.DbContext;
using nest.core.dominio.Cache;

namespace nest.core.infraestructura.db.Cache
{
    public abstract class CachedRepositoryBase<T> where T : class
    {
        protected readonly NestDbContext context;
        protected readonly ICacheRepository cache;
        private readonly string cacheKey;

        protected CachedRepositoryBase(NestDbContext context, ICacheRepository cache)
        {
            this.context = context;
            this.cache = cache;
            cacheKey = typeof(T).Name;
        }

        protected virtual IQueryable<T> Query() =>
            context.Set<T>().AsNoTracking();

        protected virtual TimeSpan CacheDuration => TimeSpan.FromHours(12);

        protected async Task<List<T>> GetCachedListAsync()
        {
            var cached = await cache.GetAsync<List<T>>(cacheKey);
            if (cached is not null)
                return cached;

            var data = await Query().ToListAsync();
            await cache.SetAsync(cacheKey, data, CacheDuration);
            return data;
        }

        protected Task InvalidateCacheAsync() =>
            cache.RemoveAsync(cacheKey);
    }
}
