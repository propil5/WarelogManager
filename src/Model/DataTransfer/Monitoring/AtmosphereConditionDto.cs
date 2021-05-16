using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Utilities;

namespace WarelogManager.Model.DataTransfer.Monitoring
{
    [Table("AtmosphereCondition")]
    [Keyless]
    public class AtmosphereConditionDto
    {
        public int PlaceId { get; set; }
        public PlaceDto Place { get; set; }
        public DateTime MeasurementDate { get; set; }
        public double? Hummidity { get; set; }
        public double? TempC { get; set; }
        public double? PM10 { get; set; }
        public double? CO { get; set; }
        public double? PM25 { get; set; }
        public double? WindSpeed { get; set; }
        public double? UV { get; set; }
    }
}
