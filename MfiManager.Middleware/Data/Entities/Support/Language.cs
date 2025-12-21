namespace MfiManager.Middleware.Data.Entities.Support {
    /// <summary>
    /// Language spoken by an individual
    /// </summary>
    public class Language : BaseEntity {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual ICollection<IndividualLanguage> Individuals { get; set; } = [];
        public virtual ICollection<MemberLanguage> Members { get; set; } = [];
        public virtual ICollection<GuarantorLanguage> Guarantors  {get;set;} = [];
    }
}
