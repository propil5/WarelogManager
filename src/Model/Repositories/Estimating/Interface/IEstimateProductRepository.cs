using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Estimating;

namespace WarelogManager.Model.Repositories.Estimating.Interface
{
    public interface IEstimateProductRepository
    {
        Task<int?> Add(EstimateProductDto place);
        void Delete(EstimateProductDto place);
        Task<IEnumerable<EstimateProductDto>> Get();
        Task<EstimateProductDto> GetById(int id);
        void Update(EstimateProductDto place);
    }
}