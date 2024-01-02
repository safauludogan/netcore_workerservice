
namespace DataAccess.DBModel;

public partial class PersonelTransaction
{
    public int TransactionId { get; set; }

    public int? CompanyId { get; set; }

    public DateOnly? Tarih { get; set; }

    public int? PersonelId { get; set; }

    public int? TerminalId { get; set; }

    public string? Kaynak { get; set; }

    public string? Yon { get; set; }

    public string? Aktif { get; set; }
}
