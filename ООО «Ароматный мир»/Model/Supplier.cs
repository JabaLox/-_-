using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int IdSupplier { get; set; }
        public string NameSupplier { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
