using DataAccess.Base;

namespace DataAccess.DBModel;

public partial class Employee : IEntity
{
    public string? StaffNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? IdentityNumber { get; set; }

    public string? Phone { get; set; }

    public string? WorkEmail { get; set; }

    public string? Gender { get; set; }

    public string? Language { get; set; }

    public string? BirthDate { get; set; }

    public string? HiredDate { get; set; }

    public string? Unit { get; set; }

    public string? Branch { get; set; }

    public string? Role { get; set; }

    public string? Company { get; set; }
}
