using System.ComponentModel;

namespace MfiManager.Middleware.Enums {
    public enum MailMergeOption {
        /// <summary>
        /// Never apply mail merge
        /// </summary>
        None = 0,
        /// <summary>
        /// Mail merge at loan application
        /// </summary>
        Application = 1,
        /// <summary>
        /// Mail merge at loan disbursement
        /// </summary>
        Disbursement = 2
    }
}
