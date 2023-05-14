using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Ordersstatus
    {
        public Ordersstatus()
        {
            Orders = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string NameStatus { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
