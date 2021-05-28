using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Warehouse;
using WarelogManager.Model.Mapping;
using Microsoft.EntityFrameworkCore;
using WarelogManager.Model.Repositories.Warehouse.Interface;

namespace WarelogManager.Model.Repositories.Warehouse
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(CompanyDto Company)
        {
            await _context.Companies.AddAsync(Company);
            await _context.SaveChangesAsync();
            return Company.Id;
        }

        public async Task<IEnumerable<CompanyDto>> Get()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<CompanyDto> GetById(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public void Update(CompanyDto company)
        {
            _context.Companies.Update(company);
        }

        public void Delete(CompanyDto company)
        {
            _context.Companies.Remove(company);
        }
    }
}
