namespace MfiManager.Middleware.Configuration {
    /// <summary>
    /// Static Cache Service Interface
    /// </summary>
    public interface IStaticCacheManager {
        Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, TimeSpan? cacheTime = null);
        T Get<T>(string key, Func<T> acquire, TimeSpan? cacheTime = null);
        Task SetAsync(string key, object data, TimeSpan? cacheTime = null);
        void Set(string key, object data, TimeSpan? cacheTime = null);
        bool IsSet(string key);
        void Remove(string key);
        void RemoveByPrefix(string prefix);
        void Clear();
    }

}
