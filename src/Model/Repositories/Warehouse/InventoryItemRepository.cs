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
    public class InventoryItemRepository : BaseRepository, IInventoryItemRepository
    {
        public InventoryItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(InventoryItemDto inventoryItem)
        {
            await _context.InventoryItems.AddAsync(inventoryItem);
            await _context.SaveChangesAsync();
            return inventoryItem.Id;
        }

        public async Task<IEnumerable<InventoryItemDto>> Get()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<InventoryItemDto> GetById(int id)
        {
            return await _context.InventoryItems.FindAsync(id);
        }

        public void Update(InventoryItemDto inventoryItem)
        {
            _context.Update(inventoryItem);
        }

        public void Delete(InventoryItemDto inventoryItem)
        {
            _context.InventoryItems.Remove(inventoryItem);
        }
    }
}
