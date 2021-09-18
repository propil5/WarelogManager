using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Repositories.Sales.Interface
{
    public interface IBasketItemRepository
    {
        Task<bool> Add(BasketItemDto salesOrderLine);
        void Delete(BasketItemDto salesOrderLine);
        Task<IEnumerable<BasketItemDto>> Get();
        Task<IEnumerable<BasketItemDto>> Get(string userId);
        Task<BasketItemDto> Get(int id);
        void Update(BasketItemDto salesOrderLine);
    }
}
