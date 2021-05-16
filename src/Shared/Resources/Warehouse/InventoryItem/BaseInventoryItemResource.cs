using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Shared.Resources.Warehouse.InventoryItem
{
    public class BaseInventoryItemResource
    {
        public string SKULabel { get; set; }
        public int UnitOfMeasure { get; set; }
        public string Descritption { get; set; }
        public int? SizeId { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedById { get; set; }
        public int AvailableQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public string EditedById { get; set; }
        public string EdditedByEmail { get; set; }
        public DateTime? EditedDate { get; set; }
        [Required]
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
