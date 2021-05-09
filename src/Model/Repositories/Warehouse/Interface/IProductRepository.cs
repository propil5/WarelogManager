using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IProductRepository
    {
        Task<int?> Add(ProductDto product);
        Task<IEnumerable<ProductDto>> Get();
        Task<ProductDto> GetById(int id);
        void Update(ProductDto product);
        void Delete(ProductDto product);
    }
}
