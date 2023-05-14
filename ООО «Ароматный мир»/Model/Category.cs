using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int IdCategory { get; set; }
        public string NameCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
