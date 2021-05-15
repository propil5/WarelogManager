using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.Enums
{
    public enum SalesOrderStatusEnum
    {
        Created = 0,
        Submited = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4,
        Canceled = 5,
    }
}
