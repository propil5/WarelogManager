using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Client.Resources.Common
{
    public class BaseImageResource : BaseFileResource
    {
        public string Src { get; set; }
        public string Alt { get; set; }
    }
}
