using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Shared.Resources.Warehouse.InventoryItem;

namespace WarelogManager.Shared.Resources.Warehouse.Product
{
    public class BaseProductResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        [Range(0, 99999)]
        public double Weight { get; set; }
        [Range(0, 99999)]
        public double Height { get; set; }
        [Range(0, 99999)]
        public double Width { get; set; }
        [Range(0, 99999)]
        public double Depth { get; set; }
        public int PalletId { get; set; }
        public List<InventoryItemResource> InventoryItems { get; set; }
    }
}
