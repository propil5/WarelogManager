using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Repositories.Sales.Interface
{
    public interface ISalesOrderLineRepository
    {
        Task<int?> Add(SalesOrderLineDto salesOrderLine);
        void Delete(SalesOrderLineDto salesOrderLine);
        Task<IEnumerable<SalesOrderLineDto>> Get();
        Task<SalesOrderLineDto> GetById(int id);
        void Update(SalesOrderLineDto salesOrderLine);
    }
}