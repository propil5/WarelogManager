using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Repositories.Sales.Interface
{
    public interface ISalesOrderShippingRepository
    {
        Task<int?> Add(SalesOrderShippingDto salesOrderShipping);
        void Delete(SalesOrderShippingDto salesOrderShipping);
        Task<IEnumerable<SalesOrderShippingDto>> Get();
        Task<SalesOrderShippingDto> GetById(int id);
        void Update(SalesOrderShippingDto salesOrderShipping);
    }
}