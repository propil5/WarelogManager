using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Payment;

namespace WarelogManager.Model.Repositories.Payment
{
    public interface IPaymentRepository
    {
        Task<int?> Add(PaymentDto payment);
        void Delete(PaymentDto payment);
        Task<IEnumerable<PaymentDto>> Get();
        Task<PaymentDto> GetById(int id);
        void Update(PaymentDto payment);
    }
}