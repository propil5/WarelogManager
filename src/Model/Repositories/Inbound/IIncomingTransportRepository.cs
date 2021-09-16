using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Inbound;

namespace WarelogManager.Model.Repositories.Inbound
{
    public interface IIncomingTransportRepository
    {
        Task<int?> Add(IncomingTransportDto salesOrder);
        void Delete(IncomingTransportDto salesOrder);
        Task<IEnumerable<IncomingTransportDto>> Get();
        Task<IncomingTransportDto> GetById(int id);
        void Update(IncomingTransportDto salesOrder);
    }
}
