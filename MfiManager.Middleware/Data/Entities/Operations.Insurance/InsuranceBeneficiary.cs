using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Insurance {
    /// <summary>
    /// Person benefiting from the insurance policy
    /// </summary>
    public class InsuranceBeneficiary : BaseEntity {
        public string Code { get; set; }
        public bool IsClient { get; set; }
        public string ClientCode { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string RelationshipToHolder { get; set; }
        /// <summary>
        /// Get/Set whether beneficiary is exclude from current policy
        /// </summary>
        public bool ExcludeFromPolicy { get; set; }
        public virtual ICollection<PolicyInsuranceBeneficiary> Policies {get;set;}=[];
    }


}
