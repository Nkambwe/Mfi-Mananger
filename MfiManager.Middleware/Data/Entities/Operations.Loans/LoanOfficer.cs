using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Operations.Loans {

    /// <summary>
    /// Class represents loan officers like Credit Officers, Credit Analysts, Senior Credit Analysts, Disbursement officers
    /// </summary>
    public class LoanOfficer: BaseEntity {
        /// <summary>
        /// Officer seriess like CO-001[Credit Office], CA-001[Credit Analyst], SC-001[Senior Credit Analyst], etc
        /// </summary>
        public string Series {get;set;}
        public OfficerLevel Level {get;set;}
        public string Position { get; set; }
        public bool Suspended { get; set; }
        public long UserId {get;set; }
        public virtual SystemUser User { get; set; }
        public long BranchId {get;set; }
        public virtual Branch Branch { get; set; }
        public virtual ICollection<LoanRecord> Loans { get; set; }
    }

}
