using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Shared.Resources.Warehouse.InventoryItem;

namespace WarelogManager.Client.Resources.Sales
{
    public class BasketItemResource
    {
        public int Quantity { get; set; }
        public int InventoryItemId { get; set; }
        public InventoryItemResource InventoryItem { get; set; }
    }
}
