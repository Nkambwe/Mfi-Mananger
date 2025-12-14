namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Insurance claimant
    /// </summary>
    public class Claimant: BaseEntity {
        public string ClaimantName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public virtual ICollection<InsuranceClaim> Claims {get;set; }=[];
        public virtual ICollection<ClaimReceipt> Receipts {get;set; }=[];
    }
}
