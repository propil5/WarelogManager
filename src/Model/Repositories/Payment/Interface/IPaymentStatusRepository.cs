using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Payment;

namespace WarelogManager.Model.Repositories.Payment
{
    interface IPaymentStatusRepository
    {
        Task<int?> Add(PaymentStatusDto paymentStatus);
        void Delete(PaymentStatusDto paymentStatus);
        Task<IEnumerable<PaymentStatusDto>> Get();
        Task<PaymentStatusDto> GetById(int id);
        void Update(PaymentStatusDto paymentStatus);
    }
}