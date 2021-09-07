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
    public class PurchaseOrderRepository : BaseRepository, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> Add(PurchaseOrderDto basketItem)
        {
            try
            {
                await _context.PurchaseOrders.AddAsync(basketItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<PurchaseOrderDto>> Get()
        {
            return await _context.PurchaseOrders.ToListAsync();
        }

        public async Task<PurchaseOrderDto> GetById(int id)
        {
            return await _context.PurchaseOrders.FindAsync(id);
        }

        public void Update(PurchaseOrderDto basketItemDto)
        {
            _context.PurchaseOrders.Update(basketItemDto);
        }

        public void Delete(PurchaseOrderDto basketItemDto)
        {
            _context.PurchaseOrders.Remove(basketItemDto);
        }
    }
}
