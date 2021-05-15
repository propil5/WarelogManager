using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.DataTransfer.Common
{
    public class BasePositionDto : BaseEntity
    {
        public DateTime PostitionDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
