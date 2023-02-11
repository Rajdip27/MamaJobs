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
    public class EmploymentStatus:BaseEntity
    {
        [Required]
        [DisplayName("Employment Status Name")]
        public string EmploymentStatusName { get; set; }
    }
}
