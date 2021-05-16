using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.DataTransfer.Common
{
    public class ChangeTrackedEntity : BaseEntity
    {
        public string AddedById { get; set; }
        public ApplicationUser AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public string EditedById { get; set; }
        public ApplicationUser EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
    }
}
