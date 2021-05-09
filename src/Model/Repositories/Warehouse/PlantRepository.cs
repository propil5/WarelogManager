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
    public class PlantRepository : BaseRepository, IPlantRepository
    {
        public PlantRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(PlantDto plant)
        {
            await _context.Plants.AddAsync(plant);
            return plant.Id;
        }

        public async Task<IEnumerable<PlantDto>> Get()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<PlantDto> GetById(int id)
        {
            return await _context.Plants.FindAsync(id);
        }

        public void Update(PlantDto pallet)
        {
            _context.Plants.Update(pallet);
        }

        public void Delete(PlantDto plant)
        {
            _context.Remove(plant);
        }
    }
}
