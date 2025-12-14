namespace MfiManager.Middleware.Data.Entities.System.Configurations.Parameters {
    public class JournalParameters : IConfigurationParameter {
        /// <summary>
        /// Check whether to revalue FX transactions at period closure
        /// </summary>
        public bool RevalueFxTransactions { get; set; }
    }

}
