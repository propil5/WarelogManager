using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Shipping;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataTransfer.Sales
{
    [Table("PurchaseOrder")]
    public class PurchaseOrderDto : BaseEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime PurchaseTime { get; set; }
        public int ShippingMethodId { get; set; }
        public ShippingMethodDto ShippingMethod { get; set; }
        public float ToalPrice { get; set; }
    }
}
