using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Shipping;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IShippingMethodRepository
    {
        Task<bool> Add(ShippingMethodDto basketItem);
        void Delete(ShippingMethodDto basketItemDto);
        Task<IEnumerable<ShippingMethodDto>> Get();
        Task<ShippingMethodDto> GetById(int id);
        void Update(ShippingMethodDto basketItemDto);
    }
}
