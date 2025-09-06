using Microsoft.Extensions.Caching.Distributed;
using nest.core.dominio.Cache;
using System.Text.Json;

namespace nest.core.infraestructura.db.Cache
{
    public class RedisCacheRepository : ICacheRepository
    {
        private readonly IDistributedCache _distributedCache;

        public RedisCacheRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var json = await _distributedCache.GetStringAsync(key);
            return json is null ? default : JsonSerializer.Deserialize<T>(json);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan ttl)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = ttl
            };
            var json = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, json, options);
        }

        public Task RemoveAsync(string key) =>
            _distributedCache.RemoveAsync(key);
    }
}
