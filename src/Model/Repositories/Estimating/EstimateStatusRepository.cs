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
    class EstimateStatusRepository : BaseRepository, IEstimateStatusRepository
    {
        public EstimateStatusRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(EstimateStatusDto estimateStatus)
        {
            await _context.EstimateStatuses.AddAsync(estimateStatus);
            await _context.SaveChangesAsync();
            return estimateStatus.Id;
        }

        public async Task<IEnumerable<EstimateStatusDto>> Get()
        {
            return await _context.EstimateStatuses.ToListAsync();
        }

        public async Task<EstimateStatusDto> GetById(int id)
        {
            return await _context.EstimateStatuses.FindAsync(id);
        }

        public void Update(EstimateStatusDto estimateStatus)
        {
            _context.EstimateStatuses.Update(estimateStatus);
        }

        public void Delete(EstimateStatusDto estimateStatus)
        {
            _context.EstimateStatuses.Remove(estimateStatus);
        }
    }
}
