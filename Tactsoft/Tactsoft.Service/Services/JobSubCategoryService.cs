using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class JobSubCategoryService : BaseService<JobSubCategory>, IJobSubCategoryService
    {
        private readonly AppDbContext appDbContext;
        public JobSubCategoryService(AppDbContext context) : base(context)
        {
            this.appDbContext = context;
        }
    }
}
