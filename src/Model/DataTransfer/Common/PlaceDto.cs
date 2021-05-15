using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.DataTransfer.Common
{
    [Table("Address")]
    public class PlaceDto : PositionDto
    {
        public string Name { get; set; }
        public bool Inside { get; set; }
    }
}
