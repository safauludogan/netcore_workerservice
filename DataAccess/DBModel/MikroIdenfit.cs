
namespace DataAccess.DBModel;

public partial class MikroIdenfit
{
    public decimal? StaffNumber { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal? IdentityNumber { get; set; }

    public string? WorkMail { get; set; }

    public string? Phone { get; set; }

    public string? Gender { get; set; }

    public string? Language { get; set; }

    public DateOnly? HiredDate { get; set; }

    public string? Unit { get; set; }

    public string? Branch { get; set; }

    public string? Company { get; set; }

    public string? Role { get; set; }
}
