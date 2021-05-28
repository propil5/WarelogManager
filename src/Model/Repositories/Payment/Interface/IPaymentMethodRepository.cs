using System.Collections.Generic;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Payment;

namespace WarelogManager.Model.Repositories.Payment
{
    interface IPaymentMethodRepository
    {
        Task<int?> Add(PaymentMethodDto place);
        void Delete(PaymentMethodDto place);
        Task<IEnumerable<PaymentMethodDto>> Get();
        Task<PaymentMethodDto> GetById(int id);
        void Update(PaymentMethodDto place);
    }
}