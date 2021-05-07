using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Inbound
{
    public class SupplierDto : BaseEntity
    {
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int BillingAcc { get; set; }
        public int Priority { get; set; }
    }
}
