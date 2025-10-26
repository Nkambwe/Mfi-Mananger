using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum GroupScope {
          [Description("Undefined")]
          UNDEFINED = 0,
          [Description("System")]
          SYSTEM = 1,
          [Description("Department")]
          DEPARTMENTAL = 2
    }
}
