using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum AccountCategory {
        /// <summary>
        /// Top level ledger label
        /// </summary>
        None = 0,
        /// <summary>
        /// Ledger Account category eg. Asset, Liability, Equity, Revenue, Expense
        /// </summary>
        Category = 1,
        /// <summary>
        /// Ledger Account sub category eg. Fixed Assets, Current Assets
        /// </summary>
        [Description("Sub Category")]
        SubCategory = 2,
        /// <summary>
        /// Ledger Account Header eg. Motor Vehicles
        /// </summary>
        Header = 3,
        /// <summary>
        /// Ledger Account eg. Trucks
        /// </summary>
        Ledger = 4,
        /// <summary>
        /// Ledger Account header totals eg. Total Trucks
        /// </summary>
        [Description("Header Total")]
        HeaderTotal = 5,
        /// <summary>
        /// Ledger Accounts sub totals eg. Total Fixed Assets, Total Current Assets
        /// </summary>
        [Description("Sub Total")]
        SubTotal = 6,
        /// <summary>
        /// Ledger accounts category total eg. Total Assets
        /// </summary>
        [Description("Category total")]
        CategoryTotal = 7,
        /// <summary>
        /// Overall total eg. Equity + Liabilities
        /// </summary>
        [Description("Grand Total")]
        GrandTotal = 8
    }
}
