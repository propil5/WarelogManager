using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Accounting;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Inbound
{
    [Table("Supplier")]
    public class SupplierDto : BaseEntity
    {
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int BillingAccId { get; set; }
        public BillingAccountDto BillingAcc { get; set; }
        public int Priority { get; set; }
    }
}
