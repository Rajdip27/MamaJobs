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
    public class JobCategory:BaseEntity
    {
        [Required]
        [DisplayName("Job Category Name")]
        public string JobCategoryName { get; set; }
        public ICollection<JobSubCategory>  JobSubCategories { get; set; }
    }
}
