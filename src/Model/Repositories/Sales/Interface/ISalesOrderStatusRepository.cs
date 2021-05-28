using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Repositories.Sales.Interface
{
    public interface ISalesOrderStatusRepository
    {
        Task<int?> Add(SalesOrderStatusDto salesOrderStatus);
        void Delete(SalesOrderStatusDto salesOrderStatus);
        Task<IEnumerable<SalesOrderStatusDto>> Get();
        Task<SalesOrderStatusDto> GetById(int id);
        void Update(SalesOrderStatusDto salesOrderStatus);
    }
}