using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataTransfer.Inbound
{
    [Table("Supply")]
    public class SupplyDto : BaseEntity
    {
        public int SupplyOrderId { get; set; }
        public SupplyOrderDto SupplyOrder { get; set; }
        public int ItemId { get; set; }
        public SalesOrderLineDto Item { get; set; }
    }
}
