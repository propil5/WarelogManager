using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Warehouse
{
    [Table("InventoryItemImage")]
    public class InventoryItemImageDto : FileDto
    {
        public int InventoryItemId { get; set; }
        public InventoryItemDto InventoryItem { get; set; }
    }
}
