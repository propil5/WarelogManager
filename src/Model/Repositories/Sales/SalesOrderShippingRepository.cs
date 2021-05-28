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
    public class SalesOrderShippingRepository : BaseRepository, ISalesOrderShippingRepository
    {
        public SalesOrderShippingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(SalesOrderShippingDto salesOrderShipping)
        {
            await _context.SalesOrderShippings.AddAsync(salesOrderShipping);
            await _context.SaveChangesAsync();
            return salesOrderShipping.Id;
        }

        public async Task<IEnumerable<SalesOrderShippingDto>> Get()
        {
            return await _context.SalesOrderShippings.ToListAsync();
        }

        public async Task<SalesOrderShippingDto> GetById(int id)
        {
            return await _context.SalesOrderShippings.FindAsync(id);
        }

        public void Update(SalesOrderShippingDto salesOrderShipping)
        {
            _context.SalesOrderShippings.Update(salesOrderShipping);
        }

        public void Delete(SalesOrderShippingDto salesOrderShipping)
        {
            _context.SalesOrderShippings.Remove(salesOrderShipping);
        }
    }
}
