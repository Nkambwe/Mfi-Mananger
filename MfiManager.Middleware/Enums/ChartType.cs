using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum ChartType {
        Unknown = 0,
        [Description("US-UK")]
        UsUk = 1,
        [Description("FR")]
        French = 2
    }
}
