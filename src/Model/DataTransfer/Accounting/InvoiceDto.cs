using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Accounting
{
    [Table("Invoice")]
    public class InvoiceDto : BaseEntity
    {
        public double TotalCost { get; set; }
        public double Tax { get; set; }
        public int InvoiceFromId { get; set; }
        public BillingAccountDto InvoiceFrom { get; set; }
        public int InvoiceForId { get; set; }
        public BillingAccountDto InvoiceFor { get; set; }

    }
}
