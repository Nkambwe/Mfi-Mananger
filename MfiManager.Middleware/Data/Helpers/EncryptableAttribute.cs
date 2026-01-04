namespace MfiManager.Middleware.Data.Helpers {
    [AttributeUsage(AttributeTargets.Property)]
    public class EncryptableAttribute(string displayName) : Attribute {
        public string DisplayName { get; } = displayName;
    }

}
