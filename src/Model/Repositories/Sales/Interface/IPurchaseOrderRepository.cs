using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Repositories.Sales.Interface
{
    public interface IPurchaseOrderRepository
    {
        Task<bool> Add(PurchaseOrderDto basketItem);
        void Delete(PurchaseOrderDto basketItemDto);
        Task<IEnumerable<PurchaseOrderDto>> Get();
        Task<PurchaseOrderDto> GetById(int id);
        void Update(PurchaseOrderDto basketItemDto);
    }
}
