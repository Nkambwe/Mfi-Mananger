using MfiManager.Middleware.Data.Entities.System;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Audits {
    public class ModifiedRegistrationFee : BaseEntity {
        public string Client { get; set; }
        public string Voucher { get; set; }
        public string FeeType { get; set; }
        public string Ledger { get; set; }
        public string Transaction { get; set; }
        public DateTime PaidOn { get; set; }
        public string Particulars { get; set; }
        public Payment Payment { get; set; }
        public decimal Amount { get; set; }
        public string Cashier { get; set; }
        public string ModClient { get; set; }
        public string ModVoucher { get; set; }
        public string ModFeeType { get; set; }
        public string ModLedger { get; set; }
        public string ModTransaction { get; set; }
        public DateTime ModPaidOn { get; set; }
        public string ModParticulars { get; set; }
        public Payment ModPayment { get; set; }
        public decimal ModAmount { get; set; }
        public string ModCashier { get; set; }
        public long UserId { get; set; }
        public SystemUser User { get; set; }
    }
}
