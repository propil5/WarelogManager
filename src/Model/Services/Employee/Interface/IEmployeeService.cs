using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Employee;

namespace WarelogManager.Model.Services.Employee.Interface
{
    public interface IEmployeeService
    {
        Task<DtoResponse> Add(EmployeeDto employee);
        Task<DtoResponse> DeleteAsync(int id);
        Task<IEnumerable<EmployeeDto>> Get();
        Task<EmployeeDto> Get(int id);
        Task<DtoResponse> Update(int id, EmployeeDto employee);
    }
}
