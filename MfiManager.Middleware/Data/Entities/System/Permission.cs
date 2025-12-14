namespace MfiManager.Middleware.Data.Entities.System {
    public class Permission : BaseEntity {
        public string Code {get;set;}
        public string Description {get;set; }
        public virtual ICollection<PermissionSet> PermissionSets {get;set;}=[];
        public virtual ICollection<DelegatePermission> DelegatePermissions {get;set;}=[];
        /// <summary>
        /// Override equals method
        /// </summary>
        /// <param name="otherPermission">Object to compare to <code>this<see cref="Permission"/></code></param>
        /// <returns>
        /// True if <param name="otherPermission"></param> object is the same as this permission, false otherwise.
        /// </returns>
        public override bool Equals(object otherPermission) {

            if (otherPermission == null || otherPermission.GetType() != typeof(Permission))
                return false;

            if (ReferenceEquals(this, otherPermission))
                return true;

            var permission = otherPermission as Permission;

            // ReSharper disable once PossibleNullReferenceException
            return permission.Id == Id
                   && permission.Code.Trim().Equals(Code.Trim(), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Generate a hash code for this permission. 
        /// </summary>
        /// <returns>
        /// </returns>
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;

        /// <summary>
        /// Compares two instances of objects for equality.
        /// </summary>
        /// <param name="thisPermission">The First instance to compare.</param>
        /// <param name="thatPermission">The second instance to compare.</param>
        /// <returns>
        /// True when the Permissions are the same, false otherwise.
        /// </returns>
        public static bool operator ==(Permission thisPermission, Permission thatPermission)
            => thatPermission?.Equals(thisPermission) ?? Equals(thisPermission, null);

        /// <summary>
        /// Compares two instances of <see cref="Permission"/> objects for inequality.
        /// </summary>
        /// <param name="thisPermission">The First instance to compare.</param>
        /// <param name="thatPermission">The second instance to compare.</param>
        /// <returns>
        /// False when the Permissions are the same, true otherwise.
        /// </returns>
        public static bool operator !=(Permission thisPermission, Permission thatPermission)
            => !(thatPermission == thisPermission);

        /// <summary>
        /// Override the Permission's toString() method
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Code.Trim()}-{ Description.Trim()}";
    }

}
