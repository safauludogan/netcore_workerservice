using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBModel;

public partial class DataContext : DbContext
{
	public DataContext()
	{
	}

	public DataContext(DbContextOptions<DataContext> options)
		: base(options)
	{
	}



	/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Server=DESKTOP-D4CPGQD\\SQLSERDEV;Database=VIBE_DEKA;User Id=sa;password=sas;Trusted_Connection=True;TrustServerCertificate=true;");*/


	public virtual DbSet<MikroIdenfit> MikroIdenfits { get; set; }

	public virtual DbSet<PersonelTransaction> PersonelTransactions { get; set; }

	public virtual DbSet<VibeAraTablo> VibeAraTablos { get; set; }

	public virtual DbSet<VibeIdenfitBilgi> VibeIdenfitBilgis { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<MikroIdenfit>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("mikro_idenfit");

			entity.Property(e => e.BirthDate).HasColumnName("birthDate");
			entity.Property(e => e.Branch)
				.HasMaxLength(250)
				.HasColumnName("branch");
			entity.Property(e => e.Company)
				.HasMaxLength(250)
				.HasColumnName("company");
			entity.Property(e => e.FirstName)
				.HasMaxLength(250)
				.HasColumnName("firstName");
			entity.Property(e => e.Gender)
				.HasMaxLength(50)
				.HasColumnName("gender");
			entity.Property(e => e.HiredDate).HasColumnName("hiredDate");
			entity.Property(e => e.IdentityNumber)
				.HasColumnType("numeric(11, 0)")
				.HasColumnName("identityNumber");
			entity.Property(e => e.Language)
				.HasMaxLength(50)
				.HasColumnName("language");
			entity.Property(e => e.LastName)
				.HasMaxLength(250)
				.HasColumnName("lastName");
			entity.Property(e => e.Phone)
				.HasMaxLength(250)
				.HasColumnName("phone");
			entity.Property(e => e.Role)
				.HasMaxLength(250)
				.HasColumnName("role");
			entity.Property(e => e.StaffNumber)
				.HasColumnType("numeric(13, 0)")
				.HasColumnName("staffNumber");
			entity.Property(e => e.Unit)
				.HasMaxLength(250)
				.HasColumnName("unit");
			entity.Property(e => e.WorkMail)
				.HasMaxLength(250)
				.HasColumnName("workMail");
		});

		modelBuilder.Entity<PersonelTransaction>(entity =>
		{
			entity.HasKey(e => e.TransactionId).HasName("PK__Personel__55433A4B8F1C046F");

			entity.ToTable("PersonelTransaction");

			entity.Property(e => e.TransactionId)
				.ValueGeneratedNever()
				.HasColumnName("TransactionID");
			entity.Property(e => e.Aktif).HasMaxLength(255);
			entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
			entity.Property(e => e.Kaynak)
				.HasMaxLength(255)
				.IsUnicode(false);
			entity.Property(e => e.PersonelId).HasColumnName("PersonelID");
			entity.Property(e => e.TerminalId).HasColumnName("TerminalID");
			entity.Property(e => e.Yon)
				.HasMaxLength(10)
				.IsUnicode(false);
		});

		modelBuilder.Entity<VibeAraTablo>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("vibe_araTablo");

			entity.Property(e => e.IdenfitId).HasColumnName("idenfitID");
			entity.Property(e => e.PersonelId).HasColumnName("personelID");
		});

		modelBuilder.Entity<VibeIdenfitBilgi>(entity =>
		{
			entity
				.HasNoKey()
				.ToTable("vibe_idenfit_bilgi");

			entity.Property(e => e.Idenfit).HasColumnName("idenfit");
			entity.Property(e => e.PersonelAdi)
				.HasMaxLength(250)
				.HasColumnName("personelAdi");
			entity.Property(e => e.PersonelSoyAdi)
				.HasMaxLength(250)
				.HasColumnName("personelSoyAdi");
			entity.Property(e => e.Unvan)
				.HasMaxLength(250)
				.HasColumnName("unvan");
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
