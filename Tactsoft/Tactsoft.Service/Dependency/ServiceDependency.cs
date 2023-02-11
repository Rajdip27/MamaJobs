using Tactsoft.Service.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tactsoft.Service.Services;

namespace Tactsoft.Service.Dependency
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            //services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<IStateService, StateService>();
            //services.AddScoped<ICityService, CityService>();
            //services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IIndustryTypeService,IndustryTypeService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IJobCategoryService, JobCategoryService>();
            services.AddScoped<IJobLevelService, JobLevelService>();
            services.AddScoped<IJobLocationService, JobLocationService>();
            services.AddScoped<IEmploymentStatusService,EmploymentStatusService >();


        }
    }
}
