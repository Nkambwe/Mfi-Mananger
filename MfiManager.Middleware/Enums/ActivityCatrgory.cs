using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum ActivityCatrgory {
          [Description("Anonymous")]
          ANONYMOUSE = 0,
          [Description("Role Activity")]
          ROLE = 1,
          [Description("User Activity")]
          USER = 2,
          [Description("Company Activity")]
          COMPANY = 3,
          [Description("Branch Activity")]
          BRANCH = 4,
          [Description("Department Activity")]
          DEPARTMENT = 5,
          [Description("Department Unit Activity")]
          DEPARTMENT_UNIT = 6,
          [Description("Role Group Activity")]
          ROLE_GROUP = 7,
          [Description("System Configuration Activity")]
          SYSTEM_CONFIG = 8,
    }
}
