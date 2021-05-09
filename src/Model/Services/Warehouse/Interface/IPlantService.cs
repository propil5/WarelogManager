using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Services.Warehouse.Interface
{
    public interface IPlantService
    {
        Task<DtoResponse> Add(PlantDto plant);
        Task<DtoResponse> Delete(int id);
        Task<IEnumerable<PlantDto>> Get();
        Task<PlantDto> Get(int id);
        Task<DtoResponse> Update(int id, PlantDto plant);
    }
}