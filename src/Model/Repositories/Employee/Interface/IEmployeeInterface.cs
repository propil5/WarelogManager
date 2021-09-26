using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Employee;

namespace WarelogManager.Model.Repositories.Employee.Interface
{
    public interface IEmployeeRepository
    {
        Task<bool> Add(EmployeeDto employee);
        void Delete(EmployeeDto employeeDto);
        Task<IEnumerable<EmployeeDto>> Get();
        Task<EmployeeDto> Get(int id);
        Task<IEnumerable<EmployeeDto>> Get(string userId);
        void Update(EmployeeDto employeeDto);
    }
}
