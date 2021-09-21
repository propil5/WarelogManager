using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Shipping;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.ShippingMethod
{
    public class ShippingMethodRepository : BaseRepository
    {
        public ShippingMethodRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> Add(ShippingMethodDto basketItem)
        {
            try
            {
                await _context.ShippingMethods.AddAsync(basketItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ShippingMethodDto>> Get()
        {
            return await _context.ShippingMethods.ToListAsync();
        }

        public async Task<ShippingMethodDto> GetById(int id)
        {
            return await _context.ShippingMethods.FindAsync(id);
        }

        public void Update(ShippingMethodDto basketItemDto)
        {
            _context.ShippingMethods.Update(basketItemDto);
        }

        public void Delete(ShippingMethodDto basketItemDto)
        {
            _context.ShippingMethods.Remove(basketItemDto);
        }
    }
}
