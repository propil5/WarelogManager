using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.Sales.Interface;

namespace WarelogManager.Model.Repositories.Sales
{
    public class SalesOrderStatusRepository : BaseRepository, ISalesOrderStatusRepository
    {
        public SalesOrderStatusRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(SalesOrderStatusDto salesOrderStatus)
        {
            await _context.SalesOrderStatuses.AddAsync(salesOrderStatus);
            await _context.SaveChangesAsync();
            return salesOrderStatus.Id;
        }

        public async Task<IEnumerable<SalesOrderStatusDto>> Get()
        {
            return await _context.SalesOrderStatuses.ToListAsync();
        }

        public async Task<SalesOrderStatusDto> GetById(int id)
        {
            return await _context.SalesOrderStatuses.FindAsync(id);
        }

        public void Update(SalesOrderStatusDto salesOrderStatus)
        {
            _context.SalesOrderStatuses.Update(salesOrderStatus);
        }

        public void Delete(SalesOrderStatusDto salesOrderStatus)
        {
            _context.SalesOrderStatuses.Remove(salesOrderStatus);
        }
    }
}
