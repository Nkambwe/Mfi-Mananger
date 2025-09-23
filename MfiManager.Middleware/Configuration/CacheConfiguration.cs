namespace MfiManager.Middleware.Configuration {

    public class CacheConfiguration {
        public TimeSpan DefaultCacheTime { get; set; } = TimeSpan.FromMinutes(60);
        public TimeSpan ShortTermCacheTime { get; set; } = TimeSpan.FromMinutes(3);
        public bool CacheEnabled { get; set; } = true;
    }

}
