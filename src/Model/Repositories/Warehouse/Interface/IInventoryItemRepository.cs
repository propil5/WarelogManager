using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IInventoryItemRepository
    {
        Task<int?> Add(InventoryItemDto InventoryItem);
        void Delete(InventoryItemDto InventoryItem);
        Task<IEnumerable<InventoryItemDto>> Get();
        Task<InventoryItemDto> GetById(int id);
        void Update(InventoryItemDto InventoryItem);
    }
}