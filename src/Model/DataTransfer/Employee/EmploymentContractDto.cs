using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Employee
{
    public class EmploymentContractDto : BaseEntity
    {
        public DateTime ContractDate { get; set; }
    }
}
