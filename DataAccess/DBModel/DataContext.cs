using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBModel;
//Scaffold-DbContext "Server=DESKTOP-D4CPGQD\SQLSERDEV;Database=VIBE_DEKA;User Id=sa;password=sas;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBModel -Context DataContext -force
public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Employee");

            entity.Property(e => e.BirthDate)
                .HasMaxLength(255)
                .HasColumnName("birthDate");
            entity.Property(e => e.Branch)
                .HasMaxLength(255)
                .HasColumnName("branch");
            entity.Property(e => e.Company)
                .HasMaxLength(255)
                .HasColumnName("company");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(255)
                .HasColumnName("gender");
            entity.Property(e => e.HiredDate)
                .HasMaxLength(255)
                .HasColumnName("hiredDate");
            entity.Property(e => e.IdentityNumber)
                .HasMaxLength(255)
                .HasColumnName("identityNumber");
            entity.Property(e => e.Language)
                .HasMaxLength(255)
                .HasColumnName("language");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.StaffNumber)
                .HasMaxLength(255)
                .HasColumnName("staffNumber");
            entity.Property(e => e.Unit)
                .HasMaxLength(255)
                .HasColumnName("unit");
            entity.Property(e => e.WorkEmail)
                .HasMaxLength(255)
                .HasColumnName("workEmail");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
