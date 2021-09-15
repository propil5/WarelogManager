using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Trends;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.GoogleTrends;

namespace WarelogManager.Model.Repositories.GoogleTrendss
{
    public class GoogleTrendssRepository : BaseRepository, IGoogleTrendsRepository
    {
        public GoogleTrendssRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(GoogleTrendsDto product)
        {
            await _context.GoogleTrendsData.AddAsync(product);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task<IEnumerable<GoogleTrendsDto>> Get()
        {
            return await _context.GoogleTrendsData
                .ToListAsync();
        }

        public async Task<GoogleTrendsDto> GetById(int id)
        {
            return await _context.GoogleTrendsData
                .FindAsync(id);
        }

        public void Update(GoogleTrendsDto product)
        {
            _context.Update(product);
        }

        public void Delete(GoogleTrendsDto product)
        {
            _context.GoogleTrendsData.Remove(product);
        }
    }
}

