namespace MfiManager.App.Models {

    public class BranchModel {
        public long BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public long OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationAlias { get; set; }
    }

}
