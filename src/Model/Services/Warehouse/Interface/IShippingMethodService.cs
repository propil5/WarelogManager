using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Shipping;

namespace WarelogManager.Model.Services.Warehouse.Interface
{
    public interface IShippingMethodService
    {
        Task<DtoResponse> Add(ShippingMethodDto pshippingMethod);
        Task<DtoResponse> Delete(int id);
        Task<IEnumerable<ShippingMethodDto>> Get();
        Task<ShippingMethodDto> Get(int id);
        Task<DtoResponse> Update(int id, ShippingMethodDto pshippingMethod);
    }
}
