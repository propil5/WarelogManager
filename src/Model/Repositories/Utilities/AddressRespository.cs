using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.Mapping;
using WarelogManager.Model.Repositories.Utilities.Interface;

namespace WarelogManager.Model.Repositories.Utilities
{
    public class AddressRespository : BaseRepository, IAddressRespository
    {
        public AddressRespository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(AddressDto Address)
        {
            await _context.Addresses.AddAsync(Address);
            await _context.SaveChangesAsync();
            return Address.Id;
        }

        public async Task<IEnumerable<AddressDto>> Get()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<AddressDto> GetById(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public void Update(AddressDto size)
        {
            _context.Addresses.Update(size);
        }

        public void Delete(AddressDto size)
        {
            _context.Addresses.Remove(size);
        }
    }
}
