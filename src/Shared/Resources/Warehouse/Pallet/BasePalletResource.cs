using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Client.Resources.Warehouse.Pallet
{
    public class BasePalletResource
    {
        public int? OwnerId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DispacheTime { get; set; }
    }
}
