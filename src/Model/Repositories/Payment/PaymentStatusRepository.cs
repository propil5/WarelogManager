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
    class PaymentStatusRepository : BaseRepository, IPaymentStatusRepository
    {
        public PaymentStatusRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int?> Add(PaymentStatusDto paymentStatus)
        {
            await _context.PaymentStatuses.AddAsync(paymentStatus);
            await _context.SaveChangesAsync();
            return paymentStatus.Id;
        }

        public async Task<IEnumerable<PaymentStatusDto>> Get()
        {
            return await _context.PaymentStatuses.ToListAsync();
        }

        public async Task<PaymentStatusDto> GetById(int id)
        {
            return await _context.PaymentStatuses.FindAsync(id);
        }

        public void Update(PaymentStatusDto paymentStatus)
        {
            _context.PaymentStatuses.Update(paymentStatus);
        }

        public void Delete(PaymentStatusDto paymentStatus)
        {
            _context.PaymentStatuses.Remove(paymentStatus);
        }
    }
}
