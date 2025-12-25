using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Share class depicting voting power
    /// </summary>
    public enum ShareClass {
        [Description("Two Vote Shareholder")]
        A=2,
        [Description("One Vote Shareholder")]
        B=1,
        [Description("No Vote Shareholder")]
        C=0      
    }
}
