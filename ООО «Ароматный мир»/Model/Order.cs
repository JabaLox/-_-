using System;
using System.Collections.Generic;

#nullable disable

namespace ООО__Ароматный_мир_.Model
{
    public partial class Order
    {
        public Order()
        {
            Orderproducts = new HashSet<Orderproduct>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public int OrderPickupPoint { get; set; }
        public int? Client { get; set; }
        public int? Code { get; set; }
        public int OrderStatus { get; set; }

        public virtual User ClientNavigation { get; set; }
        public virtual Pickpoint OrderPickupPointNavigation { get; set; }
        public virtual Ordersstatus OrderStatusNavigation { get; set; }
        public virtual ICollection<Orderproduct> Orderproducts { get; set; }
    }
}
