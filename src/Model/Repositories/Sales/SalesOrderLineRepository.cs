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
    public class SalesOrderLineRepository : BaseRepository, ISalesOrderLineRepository
    {
        public SalesOrderLineRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(SalesOrderLineDto salesOrderLine)
        {
            await _context.SalesOrderLines.AddAsync(salesOrderLine);
            await _context.SaveChangesAsync();
            return salesOrderLine.Id;
        }

        public async Task<IEnumerable<SalesOrderLineDto>> Get()
        {
            return await _context.SalesOrderLines.ToListAsync();
        }

        public async Task<SalesOrderLineDto> GetById(int id)
        {
            return await _context.SalesOrderLines.FindAsync(id);
        }

        public void Update(SalesOrderLineDto salesOrderLine)
        {
            _context.SalesOrderLines.Update(salesOrderLine);
        }

        public void Delete(SalesOrderLineDto salesOrderLine)
        {
            _context.SalesOrderLines.Remove(salesOrderLine);
        }
    }
}
