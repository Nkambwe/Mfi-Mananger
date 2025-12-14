using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum LabelLevel {
        /// <summary>
        /// Account header total label
        /// </summary>
        [Description("Total Label")]
        Total = 1,
        /// <summary>
        /// Account header sub-total label
        /// </summary>
        [Description("Sub-total Label")]
        SubTotal = 2
    }
}
