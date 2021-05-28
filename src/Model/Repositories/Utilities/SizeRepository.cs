using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Utilities;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.Utilities.Interface;

namespace WarelogManager.Model.Repositories.Utilities
{
    public class SizeRepository : BaseRepository, ISizeRepository
    {
        public SizeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(SizeDto size)
        {
            await _context.Sizes.AddAsync(size);
            await _context.SaveChangesAsync();
            return size.Id;
        }

        public async Task<IEnumerable<SizeDto>> Get()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<SizeDto> GetById(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }

        public void Update(SizeDto size)
        {
            _context.Sizes.Update(size);
        }

        public void Delete(SizeDto size)
        {
            _context.Sizes.Remove(size);
        }
    }
}
