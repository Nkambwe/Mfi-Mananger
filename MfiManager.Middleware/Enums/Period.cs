using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Financial period
    /// </summary>
    public enum Period {
        /// <summary>
        /// Financial period not specified
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Financial period of 12 calender months
        /// </summary>
        [Description("12 Months")]
        Calender = 1,
        /// <summary>
        /// Financial period of 12 calendar months plus last month of previous period
        /// </summary>
        [Description("13 Months")]
        CalenderPlus = 2
    }
}
