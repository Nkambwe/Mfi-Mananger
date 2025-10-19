namespace MfiManager.App.Logging {
    /// <summary>
    /// Interface implemented by the objects employing logging
    /// </summary>
    public interface IApplicationLogger {
        string Id { set; get; }
        string Channel { set; get; }
        void Log(string message, string type = "MSG");
    }

}
