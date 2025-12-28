namespace MfiManager.Middleware.Enums {
    public enum RepaymentPriority {
        /// <summary>
        /// UNdefined
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Principal,Interest,Fees and Penalty
        /// </summary>
        PrincipalInterestFeesPenalty = 1,
         /// <summary>
        /// Principal,Fees,Penalty,Interest
        /// </summary>
        PrincipalFeesPenaltyInterest = 2,
        /// <summary>
        /// Interest,Principal,Fees and Penalty
        /// </summary>
        InterestPrincipalFeesPenalty = 3
        
    }
}
