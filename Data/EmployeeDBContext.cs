using asp_member_prac.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_member_prac.Data
{
    public partial class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {
        }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("id");

                entity.Property(e => e.EmploymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("employmentDate");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .HasColumnName("gender");

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}