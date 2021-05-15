using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarelogManager.Model.DataTransfer.Common;

namespace WarelogManager.Model.DataTransfer.Common
{
    [Table("Position")]
    [Keyless]
    public class PositionDto : BasePositionDto
    {
        public int UserId { get; set; }
        public ApplicationUser User {get; set;}
    }
}
