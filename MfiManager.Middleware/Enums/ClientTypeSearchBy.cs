namespace MfiManager.Middleware.Enums {
    public enum ClientTypeSearchBy {
        /// <summary>
        /// Search all client types
        /// </summary>
        All = 0,
        /// <summary>
        /// Search only Individual person
        /// </summary>
        Person = 1,
        /// <summary>
        /// Search only group member
        /// </summary>
        Member = 2,
        /// <summary>
        /// Search only group client
        /// </summary>
        Group = 3,
        /// <summary>
        /// Search only sub-group within a group
        /// </summary>
        Cluster = 4,
        /// <summary>
        /// Search only business client
        /// </summary>
        Business = 5
    }

}
