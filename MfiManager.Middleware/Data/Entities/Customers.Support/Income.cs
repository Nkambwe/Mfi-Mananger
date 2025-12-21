namespace MfiManager.Middleware.Data.Entities.Customers.Support {
    public class Income : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<IncomeHistory> IncomeHistories { get; set; } = [];
    }
}
