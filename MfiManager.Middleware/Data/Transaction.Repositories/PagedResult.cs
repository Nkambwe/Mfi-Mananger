namespace MfiManager.Middleware.Data.Transaction.Repositories {

    public class PagedResult<T> {
        public List<T> Items { get; set; } = [];
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

        public static PagedResult<T> Empty() => new() {
            Items = [],
            TotalCount = 0,
            PageNumber = 1,
            PageSize = 10,
            TotalPages = 0,
            HasNextPage = false,
            HasPreviousPage = false
        };
    }

}
