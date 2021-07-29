using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Common;
using WarelogManager.Client.Resources.Warehouse.Identity;

namespace WarelogManager.Shared.Resources.Warehouse.InventoryItem
{
    public class InventoryItemResource : BaseInventoryItemResource
    {
        public int Id { get; set; }
        public UserResource EditedBy { get; set; }
        public UserResource AddedBy { get; set; }
    }
}
