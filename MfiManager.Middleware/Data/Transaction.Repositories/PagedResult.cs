namespace MfiManager.Middleware.Data.Transaction.Repositories {

    public class PagedResult<T> {
        public List<T> Entities { get; set; } = [];
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }

}
