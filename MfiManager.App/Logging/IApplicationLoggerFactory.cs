using System.Xml.Linq;

namespace MfiManager.App.Logging {

    public interface IApplicationLoggerFactory {
        IApplicationLogger CreateLogger();
        IApplicationLogger CreateLogger(string logName);
    }

}
