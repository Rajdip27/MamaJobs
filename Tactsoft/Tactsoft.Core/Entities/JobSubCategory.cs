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
    public class JobSubCategory:BaseEntity
    {
        [Required]
        [DisplayName("Job Sub Category Name")]
        public string JobSubCategoryName { get; set; }

        public long JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }
    }
}
