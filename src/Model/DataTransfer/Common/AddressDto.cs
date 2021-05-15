using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Common
{
    [Table("Address")]
    public class AddressDto : BaseEntity
    {
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string HouseNumber { get; set; }
        public string FlatNumber { get; set; }
    }
}
