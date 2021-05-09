using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.Common.Response;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Services.Warehouse.Interface
{
    public interface ICompanyService
    {
        Task<DtoResponse> Add(CompanyDto company);
        Task<DtoResponse> DeleteAsync(int id);
        Task<IEnumerable<CompanyDto>> Get();
        Task<CompanyDto> Get(int id);
        Task<DtoResponse> Update(int id, CompanyDto company);
    }
}