
namespace MfiManager.Middleware.Enums {
    public enum InstallmentBasedCommission {
        None = 0,
        /// <summary>
        /// Commission is calculated as a set percentage of each periodic installment payment.
        /// </summary>
        /// <remarks>
        /// Commission=Installment payment *  commission Rate
        /// </remarks>
        FixedPercentageOnCollection = 1,
        /// <summary>
        /// commission rate may decrease for each subsequent installment period, based on the reducing principal
        /// </summary>
        /// <remarks>
        /// Commission=Outstanding Balance *  applicable Rate
        /// </remarks>
        DecliningBalance = 2
    }
}
