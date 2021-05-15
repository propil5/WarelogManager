using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Accounting
{
    [Table("BillingAccount")]
    public class BillingAccountDto : BaseEntity
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Nip { get; set; }
        public double Balance { get; set; }
    }
}
