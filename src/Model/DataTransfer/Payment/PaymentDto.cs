using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.DataTransfer.Payment
{
    [Table("Payment")]
    public class PaymentDto : BaseEntity
    {
        public int? UserId { get; set; }
        public ApplicationUser User { get; set; }
        public double PayedAmount { get; set; }
        public int? OrderId { get; set; }
        public SalesOrderDto Order { get; set; }
        public int? PaymentStatusId { get; set; }
        public PaymentSatusDto PaymentStatus { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethodDto PaymentMethod { get; set; }
        public string Note { get; set; }
    }
}
