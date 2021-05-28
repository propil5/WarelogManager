using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Estimating;

namespace WarelogManager.Model.Repositories.Estimating.Interface
{
    interface IEstimateStatusRepository
    {
        Task<int?> Add(EstimateStatusDto estimateStatus);
        void Delete(EstimateStatusDto estimateStatus);
        Task<IEnumerable<EstimateStatusDto>> Get();
        Task<EstimateStatusDto> GetById(int id);
        void Update(EstimateStatusDto estimateStatus);
    }
}