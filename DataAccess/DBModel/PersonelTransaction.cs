using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBModel;

[Table("PersonelTransaction")]
public partial class PersonelTransaction
{
    [Key]
    public int TransactionID { get; set; }

    public int? CompanyID { get; set; }

    public DateOnly? Tarih { get; set; }

    public int? PersonelID { get; set; }

    public int? TerminalID { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Kaynak { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Yon { get; set; }

    [StringLength(255)]
    public string? Aktif { get; set; }
}
