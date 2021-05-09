using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Services.Warehouse.Interface
{
    public interface IProductService
    {
        Task<DtoResponse> Add(ProductDto product);
        Task<DtoResponse> Delete(int id);
        Task<IEnumerable<ProductDto>> Get();
        Task<ProductDto> Get(int id);
        Task<DtoResponse> Update(int id, ProductDto product);
    }
}