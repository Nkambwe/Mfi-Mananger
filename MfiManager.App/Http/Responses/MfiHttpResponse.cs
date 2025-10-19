using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {
    /// <summary>
    /// GRC Class handling responses
    /// </summary>
    /// <typeparam name="T">Success Data object type</typeparam>
    /// <remarks>
    /// ...successful response
    /// var userResponse = new EntityResponse<User>(new User { Name = "John", Id = 1 });
    /// ...failed response
    /// var userErrorResponse = new EntityResponse<User>(new MfiManagerError(ResponseCodes.UNAUTHORIZED, 
    /// "You're not authorized to access resource",
    /// "Your profile is not configure for resources above 40,000,000 UGX"));
    /// </remarks>
    public class MfiHttpResponse<T> where T : class {

        [JsonPropertyName("hasError")]
        public bool HasError { get; set; } 

        [JsonPropertyName("error")]
        public MfiHttpErrorResponse Error { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }

        /// <summary>
        /// Default C'tr
        /// </summary>
        public MfiHttpResponse() { }

        /// <summary>
        /// Ctr for success responses
        /// </summary>
        /// <param name="data">Success response data object</param>
        public MfiHttpResponse(T data) {
            HasError = false;
            Data = data;
            Error = null;
        }

        /// <summary>
        /// Ctr for failed responses
        /// </summary>
        /// <param name="error">Error response data object</param>
        public MfiHttpResponse(MfiHttpErrorResponse error) {
            HasError = true;
            Error = error;
            Data = null;
        }
    }

}
