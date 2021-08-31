using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataTransfer.Sales
{
    [Table("BasketItem")]
    [Keyless]
    public class BasketItemDto
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser {get; set; }
        public DateTime AddedAt { get; set; }
        public int Quantity { get; set; }
        public int InventoryItemId { get; set; }
        public InventoryItemDto InventoryItem { get; set; }
    }
}
