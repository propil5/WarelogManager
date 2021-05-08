using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.Repositories.Warehouse.Interface;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool Add(CompanyDto Company)
        {
            _context.Companies.Add(Company);
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public IEnumerable<CompanyDto> Get()
        {
            return _context.Companies;
        }

        public IEnumerable<CompanyDto> GetById(int id)
        {
            return _context.Companies.Where(x => x.Id == id);
        }

        public bool Update(CompanyDto Company)
        {
            var exisitngCompany = _context.Companies
                .Where(x => x.Id == Company.Id)
                .SingleOrDefault();


            if (exisitngCompany == null)
            {
                return false;
            }

            //TODO: add this update logic

            _context.Update(exisitngCompany);
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public bool Delete(int id)
        {
            var deleted = false;
            var Company = _context.Companies
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (Company != null)
            {
                _context.Remove(Company);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = _context.SaveChanges();
            return saveResult == 1 && deleted == true;
        }
    }
}
