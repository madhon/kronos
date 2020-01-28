namespace Kronos
{
    using System;
    using System.Runtime.Caching;
    using System.Threading.Tasks;

    public static class SimpleMemoryCache
    {
        private static readonly MemoryCache Cache = MemoryCache.Default;
        private static int cacheTimeInMinutes = 15;

        private static readonly CacheItemPolicy CachePolicy = new CacheItemPolicy
            {SlidingExpiration = TimeSpan.FromMinutes(cacheTimeInMinutes)};

        public static TItem GetOrCreate<TItem>(string key, Func<TItem> createItem)
        {
            TItem cacheEntry = default(TItem);

            if (!TryGetValue(key, out cacheEntry))
            {
                cacheEntry = createItem();
                Cache.Set(key, cacheEntry, CachePolicy);

            }

            return cacheEntry;
        }

        public static async Task<TItem> GetOrCreate<TItem>(string key, Func<Task<TItem>> createItem)
        {
            TItem cacheEntry = default(TItem);

            if (!TryGetValue(key, out cacheEntry))
            {
                cacheEntry = await createItem().ConfigureAwait(false);
                Cache.Set(key, cacheEntry, CachePolicy);
            }

            return cacheEntry;
        }

        private static bool TryGetValue<T>(string key, out T value)
        {
            var result = false;
            value = default(T);

            var item = Cache.Get(key);

            if (item != null)
            {
                value = (T) item;
                result = true;
            }

            return result;
        }
    }
}
