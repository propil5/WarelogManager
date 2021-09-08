using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Warehouse.Identity;

namespace WarelogManager.Client.Resources.Sales
{
    public class PurchaseOrderResource
    {
        public UserResource ApplicationUser { get; set; }
        public DateTime PurchaseTime { get; set; }
        public int ShippingMethodId { get; set; }
        public float ToalPrice { get; set; }
    }
}
