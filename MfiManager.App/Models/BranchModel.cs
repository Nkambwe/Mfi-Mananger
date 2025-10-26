namespace MfiManager.App.Models {

    public class BranchModel {
        public long BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string City  { get; set; }
        public string PostalAddress { get; set; }
        public string FaxNumber { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }
    }

}
