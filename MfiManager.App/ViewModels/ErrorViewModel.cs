namespace MfiManager.App.Models {
    public class ErrorViewModel {
         public int StatusCode { get; set; }
         public bool IsLive {get;set;}
         public string ErrorMessage {get;set;}
         public string ErrorPath {get;set;}
         public string OriginalPath {get;set;}
         public string OriginalQueryString {get;set;}
         public string StackTrace {get;set;}
    }
}
