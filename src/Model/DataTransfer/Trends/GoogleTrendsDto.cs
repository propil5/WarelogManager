using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataTransfer.Trends
{
    public class GoogleTrendsDto : BaseEntity
    {
        public int TrendValue { get; set; }
        public DateTime Date { get; set; }
        public int ProductId {get; set;}
        public ProductDto Product { get; set; }
    }
}
