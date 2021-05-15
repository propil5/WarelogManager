using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Estimating
{
    /// <summary>
    /// Use it for set an probablity of using that item soon or later/
    /// seting proiorty /
    /// setting some status of probability of huge demand compared to different items in the near future
    /// </summary>
    [Table("EstimateProduct")]
    public class EstimateProductDto : BaseEntity
    {
        public string EstimationDate { get; set; }
        public int EstimationStatusId { get; set; }
        public EstimateStatusDto EstimationStatus { get; set; }
        public bool? IsImportant { get; set; }
    }
}
