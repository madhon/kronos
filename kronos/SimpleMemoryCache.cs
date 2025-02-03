namespace Kronos
{
    using System;
    using Microsoft.Extensions.Caching.Memory;
    using System.Threading.Tasks;

    public static class SimpleMemoryCache
    {
        private static readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private static readonly TimeSpan DefaultCacheTime = TimeSpan.FromMinutes(15);

        public static TItem GetOrCreate<TItem>(string key, Func<TItem> createItem)
        {
            if (!TryGetValue(key, out TItem cacheEntry))
            {
                cacheEntry = createItem();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(DefaultCacheTime);
                
                _cache.Set(key, cacheEntry!, cacheEntryOptions);
            }

            return cacheEntry;
        }

        public static async Task<TItem> GetOrCreate<TItem>(string key, Func<Task<TItem>> createItem)
        {
            if (!TryGetValue(key, out TItem cacheEntry))
            {
                cacheEntry = await createItem().ConfigureAwait(false);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(DefaultCacheTime);
                
                _cache.Set(key, cacheEntry!, cacheEntryOptions);
            }

            return cacheEntry;
        }

        private static bool TryGetValue<T>(string key, out T value)
        {
            return _cache.TryGetValue(key, out value!);
        }
    }
}
