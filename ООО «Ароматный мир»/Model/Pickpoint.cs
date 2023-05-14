using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Pickpoint
    {
        public Pickpoint()
        {
            Orders = new HashSet<Order>();
        }

        public int PickPointId { get; set; }
        public int? IndexPoint { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? NumberHome { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
