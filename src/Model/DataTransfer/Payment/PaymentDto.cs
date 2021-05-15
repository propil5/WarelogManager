using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Payment
{
    public class PaymentDto : BaseEntity
    {
        public int PayedById { get; set; }
        public ApplicationUser PaidBy { get; set; }
    }
}
