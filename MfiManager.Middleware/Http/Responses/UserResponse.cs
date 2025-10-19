namespace MfiManager.Middleware.Http.Responses {
    public class UserResponse {
        public long Id{get;set;}
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string MiddleName{get;set;}
        public string UserName{get;set;}
        public string EmailAddress{get;set;}
        public string DisplayName{get;set;}
        public string PhoneNumber{get;set;}
        public string PFNumber{get;set;}
        public long RoleId{get;set;}
        public string RoleName{get;set;}
        public string RoleGroup{get;set;}
        public long DepartmentId{get;set;}
        public bool IsActive{get;set;}
        public bool IsVerified{get;set;}
        public bool IsLogged{get;set;}
        public DateTime CreatedOn{get;set;}
        public string CreatedBy{get;set;}
        public DateTime? ModifiedOn{get;set;}
        public string ModifiedBy{get;set;}
    }
}
