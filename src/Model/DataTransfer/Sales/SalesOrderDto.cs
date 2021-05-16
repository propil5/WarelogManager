using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Payment;

namespace WarelogManager.Model.DataTransfer.Sales
{
    [Table("SalesOrder")]
    public class SalesOrderDto : BaseEntity
    {
        public double Cost { get; set; }
        public double Tax { get; set; }
        [Required]
        public int? OrderedById { get; set; }
        public ApplicationUser OrderedBy{get; set;}
        public int? SalesOrderStatusId { get; set; }
        public SalesOrderStatusDto SalesOrderStatus { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethodDto PaymentMethod { get; set; }
        public ICollection<SalesOrderLineDto> Product { get; set; }
    }
}
