using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;
using WarelogManager.Model.DataTransfer.User;

namespace WarelogManager.Model.DataTransfer.Warehouse
{
    [Table("Product")]
    public class CompanyDto : BaseEntity
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
