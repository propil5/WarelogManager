using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Estimating;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.Estimating.Interface;

namespace WarelogManager.Model.Repositories.Estimating
{
    public class EstimateProductRepository : BaseRepository, IEstimateProductRepository
    {
        public EstimateProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(EstimateProductDto place)
        {
            await _context.EstimateProducts.AddAsync(place);
            await _context.SaveChangesAsync();
            return place.Id;
        }

        public async Task<IEnumerable<EstimateProductDto>> Get()
        {
            return await _context.EstimateProducts.ToListAsync();
        }

        public async Task<EstimateProductDto> GetById(int id)
        {
            return await _context.EstimateProducts.FindAsync(id);
        }

        public void Update(EstimateProductDto place)
        {
            _context.EstimateProducts.Update(place);
        }

        public void Delete(EstimateProductDto place)
        {
            _context.EstimateProducts.Remove(place);
        }
    }
}
