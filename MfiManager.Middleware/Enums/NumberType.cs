using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum NumberType {
        [Description("Reference Number")]
        Reference = 1,
        [Description("Statistic Number")]
        Statistic = 2,
        [Description("Registration Number")]
        Registration = 3
    }
}
