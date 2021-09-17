using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Inbound;

namespace WarelogManager.Model.Services.Inbound
{
    public interface IIncomingTransportService
    {
        Task<DtoResponse> Add(IncomingTransportDto pallet);
        Task<DtoResponse> Delete(int id);
        Task<IEnumerable<IncomingTransportDto>> Get();
        Task<IncomingTransportDto> Get(int id);
        Task<DtoResponse> Update(int id, IncomingTransportDto pallet);
    }
}
