using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.DataAccess.Warehouse.Interface
{
    public interface IProductDao
    {
        bool Add(ProductDto product);
        bool Delete(int id);
        IEnumerable<ProductDto> Get();
        IEnumerable<ProductDto> GetById(int id);
        bool Update(ProductDto product);
    }
}
