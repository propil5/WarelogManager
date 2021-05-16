using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Warehouse
{
    [Table("Plant")]
    public class PlantDto : BaseEntity
    {
        public string Name { get; set; }
        public string PlantTypeId { get; set; }
        public int? AddressId { get; set; }
        public AddressDto Address { get; set; }
    }
}
