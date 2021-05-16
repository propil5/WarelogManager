using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Warehouse
{
    [Table("InventoryItem")]
    public class InventoryItemDto : ChangeTrackedEntity
    {
        public string SKULabel { get; set; }
        public int UnitOfMeasure { get; set; }
        public string Descritption { get; set; }
        public int? SizeId { get; set; }
        public int AvailableQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public int? ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
