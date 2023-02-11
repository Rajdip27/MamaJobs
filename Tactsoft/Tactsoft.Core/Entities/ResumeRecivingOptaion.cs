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
    public class ResumeRecivingOptaion:BaseEntity
    {
        [Required]
        [DisplayName("Resume Reciving Optaion Name")]
        public string ResumeOptaionName { get; set; }
    }
}
