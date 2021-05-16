using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Common;

namespace WarelogManager.Shared.Resources.Warehouse.InventoryItem
{
    public class InventoryItemResource : BaseInventoryItemResource
    {
        public int Id { get; set; }
        public string EditedByEmail { get; set; }
        public string AddedByEmail { get; set; }
    }
}
