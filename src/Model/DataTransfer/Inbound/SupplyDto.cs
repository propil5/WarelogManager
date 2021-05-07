using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Inbound
{
    public class SupplyDto : BaseEntity
    {
        public int SupplyOrderId { get; set; }
        public int ProductId { get; set; }
    }
}
