using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Shared.Resources.Warehouse.Company;

namespace WarelogManager.Client.Resources.Inbound
{
    public class BaseIncomingTransportResource
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public CompanyResource Company { get; set; }
        public int? StatusId { get; set; }
        public TransportStatusResource Status { get; set; }
    }
}
