using System.Collections.Generic;
using WarelogManager.Model.DataTransfer.Warehouse;

namespace WarelogManager.Model.Repositories.Warehouse.Interface
{
    public interface ICompanyRepository
    {
        bool Add(CompanyDto Company);
        bool Delete(int id);
        IEnumerable<CompanyDto> Get();
        IEnumerable<CompanyDto> GetById(int id);
        bool Update(CompanyDto Company);
    }
}