namespace MfiManager.Middleware.Data.Entities.System {

    public class SystemError: BaseEntity {
        public long CompanyId { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string Severity { get; set; }
        public string StackTrace { get; set; }
        public string Status { get; set; }

        public virtual Company Company { get; set; }
        public override bool Equals(object obj) {

            if (obj is not SystemError)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            var item = (SystemError)obj;

            if (item.IsNew() || IsNew())
                return false;

            return item.Source.Equals(Source) &&
                   item.Severity.Equals(Severity) &&
                   item.Status.Equals(Status);
        }

        public override string ToString() => $"{Source} :: {Status} {Message}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 31;
    }
}
