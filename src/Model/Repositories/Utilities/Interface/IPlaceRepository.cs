using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Utilities;

namespace WarelogManager.Model.Repositories.Utilities.Interface
{
    public interface IPlaceRepository
    {
        Task<int?> Add(PlaceDto place);
        void Delete(PlaceDto place);
        Task<IEnumerable<PlaceDto>> Get();
        Task<PlaceDto> GetById(int id);
        void Update(PlaceDto place);
    }
}