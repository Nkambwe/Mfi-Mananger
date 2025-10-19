namespace MfiManager.Middleware.Http.Responses {
    /// <summary>
    /// Pagenated response
    /// </summary>
    /// <typeparam name="T">Type of entites</typeparam>
    public class HttpListResponse<T> {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalEntities { get; set; }
        public int TotalPages { get; set; }
        public List<T> Entities { get; set; } = [];

    }

}
