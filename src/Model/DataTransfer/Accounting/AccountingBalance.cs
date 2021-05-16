using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Accounting
{
    [Table("AccountingBalance")]
    public class AccountingBalance : BaseEntity
    {
        public int? PaymentAccountId { get; set; } 
        public BillingAccountDto PaymentAccount { get; set; }
        public int? ForAccountId { get; set; }
        public BillingAccountDto ForAccount { get; set; }
        public double Balance { get; set; }
    }
}
