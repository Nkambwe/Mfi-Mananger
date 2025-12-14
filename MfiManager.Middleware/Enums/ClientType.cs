using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum ClientType {
        [Description("All Clients")]
        All = 0,
        [Description("Individuals")]
        Person = 1,
        [Description("Businesses")]
        Business = 2,
        [Description("Groups")]
        Group = 3,
        [Description("Group Members")]
        Member = 4,
        [Description("Sub Groups")]
        Cluster = 5
    }
}
