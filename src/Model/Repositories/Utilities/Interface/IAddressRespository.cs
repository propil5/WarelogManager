using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.Repositories.Utilities.Interface
{
    public interface IAddressRespository
    {
        Task<int?> Add(AddressDto Address);
        void Delete(AddressDto size);
        Task<IEnumerable<AddressDto>> Get();
        Task<AddressDto> GetById(int id);
        void Update(AddressDto size);
    }
}