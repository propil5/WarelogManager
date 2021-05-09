using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Mapping;
using Microsoft.EntityFrameworkCore;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class RackRepository : BaseRepository, IRackRepository
    {
        public RackRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(RackDto rack)
        {
            await _context.Racks.AddAsync(rack);
            return rack.Id;
        }

        public async Task<IEnumerable<RackDto>> Get()
        {
            return await _context.Racks.ToListAsync();
        }

        public async Task<RackDto> GetById(int id)
        {
            return await _context.Racks.FindAsync(id);
        }

        public void Update(RackDto rack)
        {
            _context.Racks.Update(rack);
        }

        public void Delete(RackDto rack)
        {
            _context.Racks.Remove(rack);
        }
    }
}
