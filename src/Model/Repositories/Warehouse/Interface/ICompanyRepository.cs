using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface ICompanyRepository
    {
        Task<int?> Add(CompanyDto Company);
        Task<IEnumerable<CompanyDto>> Get();
        Task<CompanyDto> GetById(int id);
        void Update(CompanyDto company);
        void Delete(CompanyDto company);
    }
}