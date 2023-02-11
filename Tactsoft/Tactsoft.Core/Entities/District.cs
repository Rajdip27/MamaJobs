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
    public class District:BaseEntity
    {
        [Required]
        [DisplayName("District Name")]
        public string DistrictName { get; set; }
        public long CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Thana>  Thanas { get; set; }
    }
}
