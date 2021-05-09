using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Services.Warehouse.Interface
{
    public interface IRackService
    {
        Task<DtoResponse> Add(RackDto rack);
        Task<DtoResponse> Delete(int id);
        Task<IEnumerable<RackDto>> Get();
        Task<RackDto> Get(int id);
        Task<DtoResponse> Update(int id, RackDto rack);
    }
}