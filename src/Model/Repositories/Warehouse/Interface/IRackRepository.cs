using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IRackRepository
    {
        Task<int?> Add(RackDto rack);
        Task<IEnumerable<RackDto>> Get();
        Task<RackDto> GetById(int id);
        void Update(RackDto rack);
        void Delete(RackDto rack);
    }
}