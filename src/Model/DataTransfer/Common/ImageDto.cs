using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarelogManager.Model.DataTransfer.Common
{
    public class FileDto : BaseEntity
    {
        public string Title { get; set; }
        public byte[] Data { get; set; }
        public string Type { get; set; }
    }
}
