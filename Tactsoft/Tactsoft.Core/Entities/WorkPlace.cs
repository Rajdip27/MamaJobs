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
    public class WorkPlace:BaseEntity
    {
        [Required]
        [DisplayName("Work Place Name")]
        public string WorkPlaceName { get; set; }
    }
}
