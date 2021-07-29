using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Warehouse
{
    [Table("Product")]
    public class ProductDto : ChangeTrackedEntity
    {
        public string Name { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public int? PalletId { get; set; }
        public PalletDto Pallet { get; set; }
        public List<InventoryItemDto> InventoryItems { get; set; }
    }
}
