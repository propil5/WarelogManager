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
    public class PositionRepository : BaseRepository, IPositionRepository
    {
        public PositionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(PositionDto position)
        {
            await _context.Positions.AddAsync(position);
            await _context.SaveChangesAsync();
            return position.Id;
        }

        public async Task<IEnumerable<PositionDto>> Get()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<PositionDto> GetById(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public void Update(PositionDto position)
        {
            _context.Positions.Update(position);
        }

        public void Delete(PositionDto position)
        {
            _context.Positions.Remove(position);
        }
    }
}
