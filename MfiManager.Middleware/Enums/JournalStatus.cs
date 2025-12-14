using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum JournalStatus {
        Undefined = 0,
        New = 1,
        Posted = 2,
        [Description("Unposted")]
        UnPosted =3,
        Void = 4,
        Reversed = 5,
        Approved = 6
    }
}
