using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor
{
    public class Order
    {
        public string OrderName { get; set; }
        public List<Product> Product { get; set; }
        public decimal Totalprice { get; set; }
        public DateTime orderData { get; set; }
        public int TrackingNumber { get; set; }
        public Shipper shipper { get; set; }
        public Customer Customer { get; set; }




    }
}
