using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Manufacture
    {
        public Manufacture()
        {
            Products = new HashSet<Product>();
        }

        public int IdManufacture { get; set; }
        public string NameManufacture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
