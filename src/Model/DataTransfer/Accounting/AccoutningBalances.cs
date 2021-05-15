using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.DataTransfer.Accounting
{
    public class AccoutningBalances
    {
        public int BalanceForId { get; set; } 
        public BillingAccountDto BalanceFor { get; set; }
        public int BalanceFromId { get; set; }
        public BillingAccountDto BalanceFrom { get; set; }
        public double Balance { get; set; }
    }
}
