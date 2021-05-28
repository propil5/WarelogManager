using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Utilities;

namespace WarelogManager.Model.Repositories.Utilities.Interface
{
    public interface ISizeRepository
    {
        Task<int?> Add(SizeDto Size);
        void Delete(SizeDto size);
        Task<IEnumerable<SizeDto>> Get();
        Task<SizeDto> GetById(int id);
        void Update(SizeDto size);
    }
}