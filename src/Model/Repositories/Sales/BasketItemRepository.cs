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
    public class BasketItemRepository : BaseRepository, IBasketItemRepository
    {
        public BasketItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> Add(BasketItemDto basketItem)
        {
            try
            {
                await _context.BasketItems.AddAsync(basketItem);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<BasketItemDto>> Get()
        {
            return await _context.BasketItems.ToListAsync();
        }

        public async Task<BasketItemDto> GetById(int id)
        {
            return await _context.BasketItems.FindAsync(id);
        }

        public void Update(BasketItemDto basketItemDto)
        {
            _context.BasketItems.Update(basketItemDto);
        }

        public void Delete(BasketItemDto basketItemDto)
        {
            _context.BasketItems.Remove(basketItemDto);
        }
    }
}
