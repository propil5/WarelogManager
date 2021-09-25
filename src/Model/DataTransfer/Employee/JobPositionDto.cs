using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Employee
{
    public class JobPositionDto : BaseEntity
    {
        public string Name { get; set; }
        public string Descrpition { get; set; }
        public int ResponsibilityLevel { get; set; }
    }
}
