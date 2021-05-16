using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Sales;

namespace WarelogManager.Model.DataTransfer.Accounting
{
    [Table("InvoiceOrder")]
    [Keyless]
    public class InvoiceOrderDto
    {
        public int? InvoiceId { get; set; }
        public InvoiceDto Invoice { get; set; }
        public int? SalesOrderId { get; set; }
        public SalesOrderDto SalesOrder { get; set; }
        
    }
}
