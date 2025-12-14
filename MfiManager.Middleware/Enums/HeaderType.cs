using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum HeaderType {
        All = 0,
        Category = 1,
        [Description("Sub Category")]
        Subcategory = 2,
        Parent = 3
    }
}
