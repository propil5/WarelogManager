using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Client.Resources.Common
{
    public class BaseFileResource
    {
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public string Type { get; set; }
    }
}
