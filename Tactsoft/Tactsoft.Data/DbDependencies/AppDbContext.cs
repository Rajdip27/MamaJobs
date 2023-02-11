using Tactsoft.Core.Entities;
using Tactsoft.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using Tactsoft.Data.DbDependencies;

namespace Tactsoft.Service.DbDependencies
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }


        #region Properties
      public DbSet<IndustryType> Industries { get; set; }
        public DbSet< ServiceType>  Services { get; set; }

        public DbSet<JobCategory>  JobCategories { get; set; }
        public DbSet<JobSubCategory>  JobSubCategories { get; set; }
        public DbSet<EmploymentStatus>  EmploymentStatuses { get; set; }
        public DbSet<JobLevel>  JobLevels { get; set; }
        public DbSet<JobLocation>  JobLocations { get; set; }
        public DbSet<WorkPlace>  WorkPlaces { get; set; }
        public DbSet<ResumeRecivingOptaion>  ResumeRecivingOptaions { get; set; }
        public DbSet<Country>  Countries { get; set; }
        public DbSet<District>  Districts { get; set; }
        public DbSet<Thana>  Thanas { get; set; }


        #endregion



        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.LogTo(message => WriteSqlQueryLog(message));
            optionsBuilder.UseLoggerFactory(_myLoggerFactory);
        }

        public const string DefaultSchemaName = "dbo";
        public string Schema { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.RelationConvetion();
            builder.DecimalConvention();
            builder.DateTimeConvention();

            builder.Seed();
        }

        public static readonly Microsoft.Extensions.Logging.LoggerFactory _myLoggerFactory = new LoggerFactory(new[] {
            new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                //new ConsoleLoggerProvider((_, __) => true, true)
        });

        private void WriteSqlQueryLog(string query, StoreType storeType = StoreType.Output)
        {
            if (storeType == StoreType.Output)
                Debug.WriteLine(query);
            else if (storeType == StoreType.Db)
            {
                // store in db
            }
            else if (storeType == StoreType.File)
            {
                // store & append in file
                //new StreamWriter("mylog.txt", append: true);
            }

            //using (WebAppContext context = new WebAppContext())
            //{
            //    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            //}

            //IQueryable queryable = from x in Blogs
            //                       where x.Id == 1
            //                       select x;

            //var sqlEf5 = ((System.Data.Objects.ObjectQuery)queryable).ToTraceString();
            //var sqlEf6 = ((System.Data.Entity.Core.Objects.ObjectQuery)queryable).ToTraceString();
            //var sql = queryable.ToString();

            // https://docs.microsoft.com/en-us/ef/ef6/fundamentals/logging-and-interception?redirectedfrom=MSDN
            // https://stackoverflow.com/questions/1412863/how-do-i-view-the-sql-generated-by-the-entity-framework
        }

        #endregion

        
    }

    public enum StoreType
    {
        Db,
        File,
        Output
    }
}
