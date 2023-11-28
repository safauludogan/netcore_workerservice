using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBModel;

public partial class DataContext : DbContext
{

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonelTransaction> PersonelTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonelTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionID).HasName("PK__Personel__55433A4B6B6AE3E0");

            entity.Property(e => e.TransactionID).ValueGeneratedNever();
        });

       /*  BoolToStringConverter converter = new("Evet", "Hayır");

        modelBuilder.Entity<PersonelTransaction>()
            .Property(e => e.Aktif)
            .HasConversion(converter);*/

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
