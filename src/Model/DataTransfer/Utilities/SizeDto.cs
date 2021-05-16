using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Utilities
{
    [Table("Size")]
    public class SizeDto : BaseEntity
    {
        public int GenderType { get; set; }
        public bool? IsKid { get; set; }
        public string EuroSize { get; set; }
        public string UkSize { get; set; }
        public string UsSize { get; set; }
        public string EuroShoeSize { get; set; }
        public string UkShoeSize { get; set; }
        public string UsShozeSize { get; set; }
    }
}
