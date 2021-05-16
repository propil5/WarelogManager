using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Inbound
{
    public class SupplyOrderDto : BaseEntity
    {
        public int? SupplierId { get; set; }
        public SupplierDto Supplier { get; set; }
        public int? OrderedById { get; set; }
        public ApplicationUser OrderBy { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int Status { get; set; }
    }
}
