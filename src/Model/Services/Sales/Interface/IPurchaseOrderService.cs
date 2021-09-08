using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Services.Sales.Interface
{
    public interface IPurchaseOrderService
    {
        Task<DtoResponse> Add(PurchaseOrderDto purchaseOrder);
        Task<DtoResponse> DeleteAsync(int id);
        Task<IEnumerable<PurchaseOrderDto>> Get();
        Task<PurchaseOrderDto> Get(int id);
        Task<DtoResponse> Update(int id, PurchaseOrderDto purchaseOrder);
    }
}
