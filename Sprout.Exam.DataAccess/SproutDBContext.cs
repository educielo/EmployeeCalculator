using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sprout.Exam.Business.Models;
using Sprout.Exam.DataAccess.EntityConfigurations;

namespace Sprout.Exam.DataAccess
{
    public class SproutDBContext : DbContext
    {
        public SproutDBContext(DbContextOptions<SproutDBContext> options)
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
