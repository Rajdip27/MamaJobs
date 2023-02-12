using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class JobCategoryService : BaseService<JobCategory>, IJobCategoryService
    {
        private readonly AppDbContext _appDbContext;
        public JobCategoryService(AppDbContext context) : base(context)
        {
            this._appDbContext = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.JobCategoryName, Value = x.Id.ToString() });
        }
    }
}
