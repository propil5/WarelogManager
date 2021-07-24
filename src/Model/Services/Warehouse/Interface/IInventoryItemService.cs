using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Services.Warehouse.Interface
{
    public interface IInventoryItemService
    {
        Task<DtoResponse> Add(InventoryItemDto inventoryItem, List<InventoryItemImageDto> inventoryItemImages = null);
        Task<DtoResponse> Delete(int id);
        Task<IEnumerable<InventoryItemDto>> Get();
        Task<InventoryItemDto> Get(int id);
        Task<DtoResponse> Update(int id, InventoryItemDto inventoryItem);
    }
}