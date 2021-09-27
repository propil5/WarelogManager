using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Client.Resources.Warehouse.Identity;

namespace WarelogManager.Client.Resources.Employee
{
    public class BaseEmployeeResource
    {
        public JobPositionResource JobPosition { get; set; }
        public UserResource User { get; set; }
        public EmployeeContractResource EmploymentContract { get; set; }
    }
}
