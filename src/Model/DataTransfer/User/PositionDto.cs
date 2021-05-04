using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.User
{
    [Table("Position")]
    public class PositionDto
    {
        public ApplicationUser User {get; set;}
        public DateTime PostitionDate {get; set;}
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
