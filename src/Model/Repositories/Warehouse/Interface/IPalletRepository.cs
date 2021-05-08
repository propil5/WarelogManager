using System.Collections.Generic;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public interface IPalletRepository
    {
        bool Add(PalletDto pallet);
        bool Delete(int id);
        IEnumerable<PalletDto> Get();
        IEnumerable<PalletDto> GetById(int id);
        bool Update(PalletDto Pallet);
    }
}