namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Standing order execution interval
    /// </summary>
    public enum OrderExecution {
        /// <summary>
        /// Unknown execution period
        /// </summary>
        Undefined = 0,
        /// <summary>
        /// Order executed on weekly basis
        /// </summary>
        Weekly = 1,
        /// <summary>
        /// Order executed every two weeks
        /// </summary>
        BiWeekly = 2,
        /// <summary>
        /// Order executed every three weeks
        /// </summary>
        TriWeekly = 3,
        /// <summary>
        /// Order executed on monthly basis
        /// </summary>
        Monthly = 4,
        /// <summary>
        /// Order executed every two months
        /// </summary>
        BiMonthly = 5,
        /// <summary>
        /// Order executed every three months
        /// </summary>
        Quarterly = 6,
        /// <summary>
        /// Order executed every four months ie. 3 quarters
        /// </summary>
        Tertiary = 7,
        /// <summary>
        /// Order executed every six months
        /// </summary>
        SemiAnnual = 8,
        /// <summary>
        /// Order executed every year
        /// </summary>
        Annual = 9,
        /// <summary>
        /// Any order execution other than those defined
        /// </summary>
        Custom = 10
    }
}
