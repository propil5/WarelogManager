using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Warehouse
{
    public class InventoryItemDto : BaseEntity
    {
        public string SKULabel { get; set; }
        public int UnitOfMeasure { get; set; }
        public string Descritption { get; set; }
        public int? SizeId { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddedById { get; set; }
        public ApplicationUser AddedBy { get; set; }
        public int AvailableQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public int? EditedById { get; set; }
        public ApplicationUser EditedBy { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
