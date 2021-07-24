using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.Warehouse.Interface;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class InventoryItemImageRepository : BaseRepository, IInventoryItemImageRepository
    {
        public InventoryItemImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(InventoryItemImageDto productImage)
        {
            await _context.InventoryItemImages.AddAsync(productImage);
            await _context.SaveChangesAsync();
            return productImage.Id;
        }

        public async Task<IEnumerable<InventoryItemImageDto>> Get()
        {
            return await _context.InventoryItemImages.ToListAsync();
        }

        public async Task<InventoryItemImageDto> GetByImageId(int imageId)
        {
            return await _context.InventoryItemImages.FindAsync(imageId);
        }

        public void Update(InventoryItemImageDto productImage)
        {
            _context.Update(productImage);
        }

        public void Delete(InventoryItemImageDto productImage)
        {
            _context.InventoryItemImages.Remove(productImage);
        }
    }
}
