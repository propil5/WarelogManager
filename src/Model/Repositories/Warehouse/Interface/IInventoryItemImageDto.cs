using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IInventoryItemImageRepository
    {
        Task<int?> Add(InventoryItemImageDto productImage);
        void Delete(InventoryItemImageDto productImage);
        Task<IEnumerable<InventoryItemImageDto>> Get();
        Task<InventoryItemImageDto> GetByImageId(int id);
        void Update(InventoryItemImageDto productImage);
    }
}