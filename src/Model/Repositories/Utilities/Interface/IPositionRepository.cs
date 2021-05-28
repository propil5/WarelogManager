using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Utilities;

namespace WarelogManager.Model.Repositories.Utilities.Interface
{
    public interface IPositionRepository
    {
        Task<int?> Add(PositionDto position);
        void Delete(PositionDto position);
        Task<IEnumerable<PositionDto>> Get();
        Task<PositionDto> GetById(int id);
        void Update(PositionDto position);
    }
}