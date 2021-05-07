using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Order
{
    public class OrderDto : BaseEntity
    {
        public int OrderBy { get; set; }
        public DateTime OrderDateTime { get; set; }

    }
}
