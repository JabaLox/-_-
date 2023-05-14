using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Product
    {
        public Product()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        public string ProductArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategory { get; set; }
        public string ProductPhoto { get; set; }
        public int ProductManufacturer { get; set; }
        public decimal ProductCost { get; set; }
        public decimal? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public decimal? MaxDiscount { get; set; }
        public string Unit { get; set; }
        public int? Supplier { get; set; }

        public virtual Category ProductCategoryNavigation { get; set; }
        public virtual Manufacture ProductManufacturerNavigation { get; set; }
        public virtual Supplier SupplierNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
