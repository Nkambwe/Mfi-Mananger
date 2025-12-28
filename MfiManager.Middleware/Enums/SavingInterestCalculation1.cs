using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum SavingInterestCalculation {
		/// <summary>
        /// No interest calculation
        /// </summary>
        [Description("No interest")]
        None = 0,
		/// <summary>
        /// Interest calculated on current running balance
        /// </summary>
        [Description("Current balance")]
		Balance = 1,
        /// <summary>
        /// Interest calculated on monthly minimum balance
        /// </summary>
        [Description("Monthly minimum balance")]
		MinimumBalance = 2,
        /// <summary>
        /// Interest calculated on period average balance
        /// </summary>
        [Description("Period Average balance")]
		PeriodAverage = 3,
        /// <summary>
        /// Interest calculated on end of period balance
        /// </summary>
        [Description("End of period balance")]
		PeriodEnd = 4,
        /// <summary>
        /// Interest calculated on end of month balance
        /// </summary>
        [Description("End of month balance")]
		MonthEnd = 5,
        /// <summary>
        /// Interest calculated by compounding balance
        /// </summary>
        [Description("Compounding balance")]
		Compounded = 6
    }
}
