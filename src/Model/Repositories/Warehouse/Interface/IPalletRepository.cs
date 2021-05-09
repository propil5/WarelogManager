using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface IPalletRepository
    {
        Task<int?> Add(PalletDto pallet);
        Task<IEnumerable<PalletDto>> Get();
        Task<PalletDto> GetById(int id);
        void Update(PalletDto pallet);
        void Delete(PalletDto pallet);
    }
}