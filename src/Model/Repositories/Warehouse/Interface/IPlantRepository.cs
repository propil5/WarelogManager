using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IPlantRepository
    {
        Task<int?> Add(PlantDto plant);
        Task<IEnumerable<PlantDto>> Get();
        Task<PlantDto> GetById(int id);
        void Update(PlantDto pallet);
        void Delete(PlantDto plant);
    }
}