using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Employee;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.Employee.Interface;

namespace WarelogManager.Model.Repositories.Employee
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> Add(EmployeeDto employee)
        {
            try
            {
                await _context.Employes.AddAsync(employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            return await _context.Employes.ToListAsync();
        }

        public async Task<IEnumerable<EmployeeDto>> Get(string userId)
        {
            return await _context.Employes
                .Include(m => m.InventoryItem)
                .ThenInclude(i => i.Images)
                .Where(x => x.ApplicationUserId == userId)
                .ToListAsync();
        }

        public async Task<EmployeeDto> Get(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public void Update(EmployeeDto employeeDto)
        {
            _context.Employees.Update(employeeDto);
        }

        public void Delete(EmployeeDto employeeDto)
        {
            _context.Employees.Remove(employeeDto);
        }
    }
}
