using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sprout.Exam.Business.Models;

namespace Sprout.Exam.DataAccess.EntityConfigurations
{
    
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        /// <summary>
        /// Configuration for the Entity-to-Schema
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee")
                    .HasKey(a => a.Id);
            builder.Property(a => a.TypeId)
                    .HasColumnName("EmployeeTypeId");
        }
    }
}