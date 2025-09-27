namespace MfiManager.Middleware.Data.Transaction.Repositories {
    /// <summary>
    /// Result class for a cursor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCursor"></typeparam>
    public class CursorPagedResult<T, TCursor> {
        public List<T> Items { get; set; } = [];
        public TCursor? NextCursor { get; set; }
        public bool HasNextPage { get; set; }
        public int PageSize { get; set; }

        public static CursorPagedResult<T, TCursor> Empty() => new() {
            Items = [],
            NextCursor = default,
            HasNextPage = false,
            PageSize = 0
        };
    }
}
