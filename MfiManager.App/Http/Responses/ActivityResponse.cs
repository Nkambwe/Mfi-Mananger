using System.Text.Json.Serialization;

namespace MfiManager.App.Http.Responses {

    public class ActivityResponse {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("userId")]
        public long UserId { get; set; }

        [JsonPropertyName("firstName")]
        public string UserFirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string UserLastName { get; set; }

        [JsonPropertyName("email")]
        public string UserEmail { get; set; }

        [JsonPropertyName("entityId")]
        public long? EntityId { get; set; }

         [JsonPropertyName("entityName")]
        public string EntityName { get; set; }

        [JsonPropertyName("typeId")]
        public long TypeId { get; set; }

        [JsonPropertyName("typeDescription")]
        public string TypeDescription { get; set; }

        [JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; }

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get;set; }

        [JsonPropertyName("period")]
        public string Period { get; set; }

        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
    }
}
