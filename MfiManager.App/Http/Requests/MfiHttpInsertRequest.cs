using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Requests {
    /// <summary>
    /// Class represent an insert for an entity request sent to the API
    /// </summary>
    /// <typeparam name="T">Type of entity being inserted</typeparam>
    public class MfiHttpInsertRequest<T>: MfiHttpRequest {

        [JsonPropertyName("record")]
        public T Record {get;set;}

    }
}
