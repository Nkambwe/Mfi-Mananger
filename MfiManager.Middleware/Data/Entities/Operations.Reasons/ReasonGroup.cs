namespace MfiManager.Middleware.Data.Entities.Operations.Reasons {

    /// <summary>
    /// Entity that has some reasons eg. Bank reasons (BAR), Exit reasons (EXR)
    /// </summary>
    public class ReasonGroup : BaseEntity {
        public string SerieIdentifier { get; set; }
        public string SeriePrefix { get; set; }
        public int LastSeries { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<GeneralReason> Reasons { get; set; } = [];

    }

}
