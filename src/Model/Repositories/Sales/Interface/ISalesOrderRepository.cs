using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.Repositories.SalesOrder.Interface
{
    public interface ISalesOrderRepository
    {
        Task<int?> Add(SalesOrderDto salesOrder);
        void Delete(SalesOrderDto salesOrder);
        Task<IEnumerable<SalesOrderDto>> Get();
        Task<SalesOrderDto> GetById(int id);
        void Update(SalesOrderDto salesOrder);
    }
}