using MfiManager.App.Http.Requests;
using MfiManager.App.Http.Responses;
using MfiManager.App.Models;

namespace MfiManager.App.Infrastructure.Utils {
    public static class Mapper {

        public static SystemErrorRequest ToSystemErrorRequest(MfiErrorModel model, string ipAddress)
            => new(){ 
                CompanyId = model.CompanyId,
                UserId = model.UserId,
                IPAddress = ipAddress,
                Source = model.Source,
                Message = model.Message,
                Severity = model.Severity,
                StackTrace = model.StackTrace
            };

        public static MfiErrorModel ToMfiErrorModel(SystemErrorRequest request)
             => new(){ 
                CompanyId = request.CompanyId,
                UserId = request.UserId,
                Source = request.Source,
                Message = request.Message,
                Severity = request.Severity,
                StackTrace = request.StackTrace
            };

          public static CurrentUserModel ToUserModel(CurrentUserResponse UserResponse)
             => new(){ 
                UserId = UserResponse.Id,
                PFNumber = UserResponse.FileNumber,
                FirstName = UserResponse.FirstName,
                MiddleName = UserResponse.MiddleName,
                LastName = UserResponse.LastName,
                FullName = UserResponse.FullName,
                Email = UserResponse.Email
            };
        
          public static BranchModel ToBranchModel(UserBranchResponse branchResponse)
             => new(){ 
                BranchId = branchResponse.Id,
                BranchCode = branchResponse.BranchCode,
                BranchName = branchResponse.BranchName,
                IsActive = branchResponse.IsDeleted
            };

        
          public static InstallationRequest ToInstallationRequest(InstallationModel model)
             => new(){ 
                CompanyName = model.Company?.CompanyName,
                RegNumber = model.Company.RegistrationNumber,
                CompanyAlias = model.Company.Alias,
                UserId = 0,
                EmailAddress = model.Owner.EmailAddress,
                ContactNumber = model.Owner.ContactNumber,
                Password = model.Owner.Password,
                DatabaseProvider = model.DatabaseProvider.DatabaseProvider,
                Action = "System Setup",
                IPAddress = "::1",
                EncryptFields = ["Password", "EmailAddress"],
                DecryptFields = []
            };

    }
}
