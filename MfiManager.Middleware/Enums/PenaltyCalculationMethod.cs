namespace MfiManager.Middleware.Enums {
    public enum PenaltyCalculationMethod {
        /// <summary>
        /// No penalty charges
        /// </summary>
         None = 0,
          /// <summary>
         /// Charge on Overdue Principal
         /// (Overdue Principal * Number of Days * Penalty rate)
         /// </summary>
         /// <remarks>
         /// Most common method where penalty rate is applied to principal
         /// due
         /// </remarks>
         OverduePrincipal = 1,
         /// <summary>
         /// Charged on overdue principal
         /// (Principal + Overdue Interest)* Number of days * Penalty rate
         /// </summary>
         /// <remarks>
         /// Method is similar to the first but includes interest
         /// </remarks>
         OverDuePrincipalWithInterest = 2,
         /// <summary>
         /// Charged on outsnading principle times number of late days times penalty rate
         /// Outstanding Principal * Number of days due * Penalty rate
         /// </summary>
         /// <remarks>
         /// If Penalty rate is changed, the accrue penalty amount is recalculated
         /// </remarks>
         OutstandingPrincipal = 3
        
    }
}
