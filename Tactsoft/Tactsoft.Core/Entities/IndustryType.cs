using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class IndustryType:BaseEntity
    {
        [Required]
        [DisplayName("Industry Type Name")]
        public string IndustryTypeName { get; set; }
    }
}
