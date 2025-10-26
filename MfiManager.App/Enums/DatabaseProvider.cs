using System.ComponentModel;

namespace MfiManager.App.Enums {
    public enum DbProvider {
        [Description("Microsoft SQL Server")]
        SqlServer,//2012
        [Description("PostgreSql")]
        PostgreSQL,//12
        [Description("Oracle DB")]
        Oracle, //21
        
    }
}
