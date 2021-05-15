using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Estimating
{
    [Table("EstimateStatus")]
    public class EstimateStatusDto : BaseEntity
    {
        public string Name { get; set; }
        public string Derscription { get; set; }
    }
}
