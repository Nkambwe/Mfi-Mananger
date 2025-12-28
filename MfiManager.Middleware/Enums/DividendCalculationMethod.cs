
namespace MfiManager.Middleware.Enums {
    public enum DividendCalculationMethod {
        None = 0,
        /// <summary>
        /// DPS shows the dividend amount for each share
        /// </summary>
        /// <remarks>
        /// DPS = Total Shares/Number of shares outstanding
        /// 5,000,000/1,000,000 Shares = 5per share
        /// </remarks>
        DividendPerShare = 1,
        /// <summary>
        /// Percentage of earnings paid as dividends
        /// </summary>
        /// <remarks>
        /// Payout rate = (Total dividends Paid /Net Income) * 100
        /// (3,000,000/10,000,000) * 100 = 30%
        /// </remarks>
        DividendPaymentRatio = 2,
        /// <summary>
        /// Calculation based on return on investment from dividends
        /// </summary>
        /// <remarks>
        /// Dividend Yield = (Annual Dividends Per Share / Current Share Price) × 100
        /// </remarks>
        DividendYeild = 3
    }
}
