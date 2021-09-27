using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Client.Resources.Employee
{
    public class JobPositionResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrpition { get; set; }
        public int ResponsibilityLevel { get; set; }
    }
}
