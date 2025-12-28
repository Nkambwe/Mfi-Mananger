namespace MfiManager.Middleware.Enums {
    public enum EnforceCollateral {
        Undefines = 0,
        /// <summary>
        /// Enforce collateral option at loan application
        /// </summary>
        Application = 1,
        /// <summary>
        /// Enforce collateral option at loan approval
        /// </summary>
        Approval = 2,
        /// <summary>
        /// Enforce collateral option at loan disbursement
        /// </summary>
        Disbursement = 3
    }
}
