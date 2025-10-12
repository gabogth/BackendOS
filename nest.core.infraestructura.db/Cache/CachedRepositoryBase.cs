using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nest.core.dominio;
using nest.core.dominio.Cache;
using nest.core.infraestructura.db.DbContext;
using nest.core.infraestructura.db.Utils;

namespace nest.core.infraestructura.db.Cache
{
    public abstract class CachedRepositoryBase<TEntity, TCreateDto, TKey> : CrudRepositoryBase<TEntity, TCreateDto, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly ICacheRepository cache;
        private readonly string cacheKey;
        protected virtual TimeSpan CacheDuration => TimeSpan.FromHours(12);

        protected CachedRepositoryBase(NestDbContext context, IMapper mapper, ICacheRepository cache): base(context, mapper)
        {
            this.cache = cache;
            cacheKey = typeof(TEntity).Name;
            if (typeof(ITenantEntity).IsAssignableFrom(typeof(TEntity)))
                cacheKey = $"{typeof(TEntity).Name}_{context.EmpresaId}";
            else
                cacheKey = $"{typeof(TEntity).Name}";
        }

        protected async Task<List<TEntity>> GetCachedListAsync()
        {
            var cached = await cache.GetAsync<List<TEntity>>(cacheKey);
            if (cached is not null)
                return cached;

            var data = await Query().ToListAsync();
            await cache.SetAsync(cacheKey, data, CacheDuration);
            return data;
        }

        protected override async Task<TEntity?> GetByIdAsync(TKey id) => (await GetCachedListAsync()).FirstOrDefault(e => e.Id!.Equals(id));
        protected override async Task<List<TEntity>> GetAllAsync() => await GetCachedListAsync();
        protected override async Task<TEntity> AddAsync(TCreateDto dto)
        {
            TEntity response = await base.AddAsync(dto);
            await InvalidateCacheAsync();
            return response;
        }
        protected override async Task<TEntity[]> AddRangeAsync(TCreateDto[] dtos)
        {
            TEntity[] response = await base.AddRangeAsync(dtos);
            await InvalidateCacheAsync();
            return response;
        }
        protected override async Task<TEntity> UpdateAsync(TKey id, TCreateDto dto)
        {
            TEntity response = await base.UpdateAsync(id, dto);
            await InvalidateCacheAsync();
            return response;
        }
        protected override async Task<TEntity[]> UpdateRangeAsync((TKey key, TCreateDto dto)[] entries)
        {
            TEntity[] response = await base.UpdateRangeAsync(entries);
            await InvalidateCacheAsync();
            return response;
        }
        protected override async Task DeleteAsync(TKey id)
        {
            await base.DeleteAsync(id);
            await InvalidateCacheAsync();
        }
        protected override async Task DeleteRangeAsync(TKey[] ids)
        {
            await base.DeleteRangeAsync(ids);
            await InvalidateCacheAsync();
        }
        protected override async Task<TEntity[]> MergeRangeAsync(TEntity[] originalEntities, (TKey key, TCreateDto dto)[] entries)
        {
            TEntity[] response = await base.MergeRangeAsync(originalEntities, entries);
            await InvalidateCacheAsync();
            return response;
        }
        protected virtual Task InvalidateCacheAsync() => cache.RemoveAsync(cacheKey);
    }
}
