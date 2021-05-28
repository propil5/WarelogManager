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
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(PaymentDto payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment.Id;
        }

        public async Task<IEnumerable<PaymentDto>> Get()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<PaymentDto> GetById(int id)
        {
            return await _context.Payments.FindAsync(id);
        }

        public void Update(PaymentDto payment)
        {
            _context.Payments.Update(payment);
        }

        public void Delete(PaymentDto payment)
        {
            _context.Payments.Remove(payment);
        }
    }
}
