using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Thana:BaseEntity
    {
        [Required]
        [DisplayName("Thana Name")]
        public string ThanaName { get; set; }
        public long DistrictId { get; set; }
        public District District { get; set; }
    }
}
