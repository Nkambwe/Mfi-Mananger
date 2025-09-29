using MfiManager.Middleware.Logging;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;

namespace MfiManager.Middleware.Configuration {

    public class MemoryStaticCacheManager(IMemoryCache memoryCache, CacheConfiguration cacheSettings, IServiceLoggerFactory loggerFactory) : IStaticCacheManager {
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly CacheConfiguration _cacheSettings = cacheSettings;
        private readonly IServiceLogger _logger = loggerFactory.CreateLogger();
        private readonly ConcurrentDictionary<string, SemaphoreSlim> _locks = new();
        private readonly ConcurrentDictionary<string, string> _allKeys = new();

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, TimeSpan? cacheTime = null) {
            if (!_cacheSettings.CacheEnabled)
                return await acquire();

            if (_memoryCache.TryGetValue(key, out T cachedValue)) {
                _logger.Log("Cache hit for key: {Key}", key);
                return cachedValue;
            }

            var semaphore = _locks.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));
            await semaphore.WaitAsync();

            try {
                //..double-check locking pattern
                if (_memoryCache.TryGetValue(key, out cachedValue))
                    return cachedValue;

                _logger.Log("Cache miss for key: {Key}, acquiring value", key);
                var result = await acquire();
                await SetAsync(key, result, cacheTime);
                return result;
            } finally {
                semaphore.Release();
            }
        }

        public T Get<T>(string key, Func<T> acquire, TimeSpan? cacheTime = null) {
            if (!_cacheSettings.CacheEnabled)
                return acquire();

            if (_memoryCache.TryGetValue(key, out T cachedValue)) {
                _logger.Log("Cache hit for key: {Key}", key);
                return cachedValue;
            }

            var semaphore = _locks.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));
            semaphore.Wait();

            try {
                if (_memoryCache.TryGetValue(key, out cachedValue))
                    return cachedValue;

                _logger.Log("Cache miss for key: {Key}, acquiring value", key);
                var result = acquire();
                Set(key, result, cacheTime);
                return result;
            } finally {
                semaphore.Release();
            }
        }

        public async Task SetAsync(string key, object data, TimeSpan? cacheTime = null) {
            if (!_cacheSettings.CacheEnabled)
                return;

            var expiration = cacheTime ?? _cacheSettings.DefaultCacheTime;
            var options = new MemoryCacheEntryOptions {
                AbsoluteExpirationRelativeToNow = expiration,
                Priority = CacheItemPriority.Normal
            };

            options.RegisterPostEvictionCallback((evictedKey, value, reason, state) => {
                _allKeys.TryRemove(evictedKey.ToString(), out _);
                _locks.TryRemove(evictedKey.ToString(), out var semaphore);
                semaphore?.Dispose();
            });

            _memoryCache.Set(key, data, options);
            _allKeys.TryAdd(key, key);
            _logger.Log($"Cached value for key: {key} with expiration: {expiration}");
        }

        public void Set(string key, object data, TimeSpan? cacheTime = null) 
            => SetAsync(key, data, cacheTime).GetAwaiter().GetResult();

        public bool IsSet(string key) => _memoryCache.TryGetValue(key, out _);

        public void Remove(string key) {
            _memoryCache.Remove(key);
            _allKeys.TryRemove(key, out _);
            if (_locks.TryRemove(key, out var semaphore))
                semaphore.Dispose();
            _logger.Log("Removed cache entry for key: {Key}", key);
        }

        public void RemoveByPrefix(string prefix) {
            var keysToRemove = _allKeys.Keys.Where(key => key.StartsWith(prefix)).ToList();
            foreach (var key in keysToRemove) {
                Remove(key);
            }
            _logger.Log($"Removed {keysToRemove.Count} cache entries with prefix: {prefix}");
        }

        public void Clear() {
            if (_memoryCache is MemoryCache mc) {
                mc.Compact(1.0);
            }
            _allKeys.Clear();
            foreach (var semaphore in _locks.Values) {
                semaphore.Dispose();
            }
            _locks.Clear();
            _logger.Log("Cleared all cache entries");
        }
    }
}
