using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Shipping
{
    [Table("ShippingMethod")]
    public class ShippingMethodDto : BaseEntity
    {
        public int Name { get; set; }
        public double Price { get; set; }
    }
}
