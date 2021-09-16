using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Inbound;
using WarelogManager.Model.DataTransfer.Sales;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.Inbound
{
    public class IncomingTransportRepository : BaseRepository, IIncomingTransportRepository
    {
        public IncomingTransportRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(IncomingTransportDto salesOrder)
        {
            await _context.IncomingTransports.AddAsync(salesOrder);
            await _context.SaveChangesAsync();
            return salesOrder.Id;
        }

        public async Task<IEnumerable<IncomingTransportDto>> Get()
        {
            return await _context.IncomingTransports.ToListAsync();
        }

        public async Task<IncomingTransportDto> GetById(int id)
        {
            return await _context.IncomingTransports.FindAsync(id);
        }

        public void Update(IncomingTransportDto salesOrder)
        {
            _context.IncomingTransports.Update(salesOrder);
        }

        public void Delete(IncomingTransportDto salesOrder)
        {
            _context.IncomingTransports.Remove(salesOrder);
        }
    }
}
