namespace MfiManager.Middleware.Data.Entities.Operations.Products {
    public class ProductType : BaseEntity {
        public string Code { get; set; }
        public int Series { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        /// <summary>
        /// Override product ToString() method
        /// </summary>
        /// <returns>Returns string representation of product class</returns>
        public override string ToString() => $"{Code}-{Name}";

        /// <summary>
        /// Override product GetHashCode() method
        /// </summary>
        /// <returns>Returns hashcode representation of product class's ToString() class</returns>
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }

}
