using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Orderproduct
    {
        public int OrderId { get; set; }
        public string ProductArticleNumber { get; set; }
        public int? Count { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product ProductArticleNumberNavigation { get; set; }
    }
}
