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
    public class ServiceType:BaseEntity
    {
        [Required]
        [DisplayName("Service Type Name")]
        public string ServiceTypeName { get; set; }
    }
}
