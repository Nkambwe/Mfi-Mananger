using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum ClientRef {
        [Description("Signatory")]
        SIN = 1,
        [Description("Business")]
        BUS = 2,
        [Description("Group")]
        GRP = 3,
        [Description("Member")]
        MEM = 4,
        [Description("Cluster")]
        CLU = 5,
        [Description("Guarantor")]
        GUA = 6
    }
}
