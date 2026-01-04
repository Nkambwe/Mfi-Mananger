using MfiManager.Middleware.Data.Entities.Operations.Branches;
using MfiManager.Middleware.Enums;

namespace MfiManager.Middleware.Data.Entities.Support {

    public class Holiday : BaseEntity {
        public Month Month { get; set; }
        public int Day { get; set; }
        /// <summary>
        /// Mark holiday as not regular. Occasional holiday are not included in new year calender unless Include is set to true
        /// </summary>
        public bool IsOccasional { get; set; }
        /// <summary>
        /// Include occasional holiday in year calender
        /// </summary>
        public bool Exclude { get; set; }
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
    }

}
