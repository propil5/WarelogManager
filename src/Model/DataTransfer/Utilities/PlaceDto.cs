using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Utilities
{
    [Table("Place")]
    public class PlaceDto : BasePositionDto
    {
        public string Name { get; set; }
        public bool Inside { get; set; }
    }
}
