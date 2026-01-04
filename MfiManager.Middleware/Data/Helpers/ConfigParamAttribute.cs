namespace MfiManager.Middleware.Data.Helpers {

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ConfigParamAttribute(string name, string description, string paramType = "string")
        : Attribute {
        public string Name { get; } = name;
        public string Description { get; } = description;
        public string ParamType { get; } = paramType;
    }

}
