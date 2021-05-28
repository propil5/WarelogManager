using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.SalesOrder.Interface;

namespace WarelogManager.Model.Repositories.SalesOrder
{
    public class SalesOrderRepository : BaseRepository, ISalesOrderRepository
    {
        public SalesOrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(SalesOrderDto salesOrder)
        {
            await _context.SalesOrders.AddAsync(salesOrder);
            await _context.SaveChangesAsync();
            return salesOrder.Id;
        }

        public async Task<IEnumerable<SalesOrderDto>> Get()
        {
            return await _context.SalesOrders.ToListAsync();
        }

        public async Task<SalesOrderDto> GetById(int id)
        {
            return await _context.SalesOrders.FindAsync(id);
        }

        public void Update(SalesOrderDto salesOrder)
        {
            _context.SalesOrders.Update(salesOrder);
        }

        public void Delete(SalesOrderDto salesOrder)
        {
            _context.SalesOrders.Remove(salesOrder);
        }
    }
}
