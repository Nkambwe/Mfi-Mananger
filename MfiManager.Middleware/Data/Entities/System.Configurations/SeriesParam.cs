using MfiManager.Middleware.Data.Entities.Operations;

namespace MfiManager.Middleware.Data.Entities.System.Configurations {
    public class SeriesParam : BaseEntity {
        public long CompanyId { get; set; }
        public string SeriesName { get; set; }
        public int LastSerie { get; set; }
        public int Starts { get; set; }
        public int? Ends { get; set; }
        public virtual Company Company { get; set; }
        public override string ToString() => $"{Id}-{SeriesName}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }

}
