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
    public class PlaceRepository : BaseRepository, IPlaceRepository
    {
        public PlaceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(PlaceDto place)
        {
            await _context.Places.AddAsync(place);
            await _context.SaveChangesAsync();
            return place.Id;
        }

        public async Task<IEnumerable<PlaceDto>> Get()
        {
            return await _context.Places.ToListAsync();
        }

        public async Task<PlaceDto> GetById(int id)
        {
            return await _context.Places.FindAsync(id);
        }

        public void Update(PlaceDto place)
        {
            _context.Places.Update(place);
        }

        public void Delete(PlaceDto place)
        {
            _context.Places.Remove(place);
        }
    }
}
