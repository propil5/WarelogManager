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
    public class PalletRepository : BaseRepository, IPalletRepository
    {
        public PalletRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(PalletDto pallet)
        {
            await _context.Pallets.AddAsync(pallet);
            await _context.SaveChangesAsync();
            return pallet.Id;
        }

        public async Task<IEnumerable<PalletDto>> Get()
        {
            return await _context.Pallets.ToListAsync();
        }

        public async Task<PalletDto> GetById(int id)
        {
            return await _context.Pallets.FindAsync(id);
        }

        public void Update(PalletDto pallet)
        {
            _context.Pallets.Update(pallet);
        }

        public void Delete(PalletDto pallet)
        {
            _context.Pallets.Remove(pallet);
        }
    }
}
