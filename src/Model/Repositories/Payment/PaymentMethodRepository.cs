using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Payment;
using WarelogManager.Model.Mapping;

namespace WarelogManager.Model.Repositories.Payment
{
    class PaymentMethodRepository : BaseRepository, IPaymentMethodRepository
    {
        public PaymentMethodRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(PaymentMethodDto place)
        {
            await _context.PaymentMethods.AddAsync(place);
            await _context.SaveChangesAsync();
            return place.Id;
        }

        public async Task<IEnumerable<PaymentMethodDto>> Get()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethodDto> GetById(int id)
        {
            return await _context.PaymentMethods.FindAsync(id);
        }

        public void Update(PaymentMethodDto place)
        {
            _context.PaymentMethods.Update(place);
        }

        public void Delete(PaymentMethodDto place)
        {
            _context.PaymentMethods.Remove(place);
        }
    }
}
