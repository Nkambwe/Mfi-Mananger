using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    /// <summary>
    /// Type of file attached
    /// </summary>
    public enum AttachmentType {
        /// <summary>
        /// Not Applicable
        /// </summary>
        [Description("NA")]
        Nap = 0,
        [Description("PDF")]
        Pdf = 1,
        [Description("TEXT")]
        Text = 2,
        [Description("WORD")]
        Document = 3,
        [Description("EXCEL")]
        Worksheet = 4,
        [Description("EPUB")]
        EPub = 5,
        [Description("IMAGE")]
        Image = 6,
        [Description("VIDEO")]
        Video = 7,
        [Description("AUSIO")]
        Audio = 8,
        [Description("OTHER")]
        Other = 9
    }
}
