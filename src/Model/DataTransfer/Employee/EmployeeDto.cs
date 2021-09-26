using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.Employee;
using WarelogManager.Model.DataTransfer.Utilities;

namespace WarelogManager.Model.DataTransfer.Employee
{
    public class EmployeeDto : BaseEntity
    {
        public int JobPositionDtoId { get; set; }
        public JobPositionDto JobPosition { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int EmploymentContractId { get; set; }
        public EmploymentContractDto EmploymentContract { get; set; }
    }
}
