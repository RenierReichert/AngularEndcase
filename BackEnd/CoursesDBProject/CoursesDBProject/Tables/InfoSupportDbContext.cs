using CoursesDBProject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CoursesDBProject.Tables
{
    public partial class InfoSupportDbContext : DbContext
    {
        private string _dbPath;

        public DbSet<Course> CoursesTable { get; set; }

        public DbSet<CourseInstance> CourseInstancesTable { get; set; }


        public InfoSupportDbContext(DbContextOptions<InfoSupportDbContext> options) : base(options)
        {
            var folder = Environment.CurrentDirectory;
            this._dbPath= folder;
            Console.WriteLine(folder);
        }
    }
}
