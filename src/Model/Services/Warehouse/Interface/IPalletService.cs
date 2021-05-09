using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Services.Warehouse.Interface
{
    public interface IPalletService
    {
        Task<DtoResponse> Add(PalletDto pallet);
        Task<IEnumerable<PalletDto>> Get();
        Task<PalletDto> Get(int id);
        Task<DtoResponse> Update(int id, PalletDto Pallet);
        Task<DtoResponse> Delete(int id);
    }
}