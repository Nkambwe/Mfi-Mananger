using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum CategoryType {
        Undefined = 0,
        [Description("First Client Category")]
        Custom1 = 1,
        [Description("Second Client Category")]
        Custom2 = 2,
        [Description("Third Client Category")]
        Custom3 = 3,
        [Description("First Member Category")]
        Member1 = 4,
        [Description("Second Member Category")]
        Member2 = 5,
        [Description("First Business Category")]
        Group1 = 6,
        [Description("Second Group Category")]
        Group2 = 7,
        [Description("First Business Category")]
        Business1 = 8,
        [Description("Second Business Category")]
        Business2 = 9
    }
}
