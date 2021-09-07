using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataTransfer.Sales
{
    public class PurchaseOrderItemDto
    {
        public int Quantity { get; set; }
        public int InventoryItemId { get; set; }
        public InventoryItemDto InventoryItem { get; set; }
    }
}
