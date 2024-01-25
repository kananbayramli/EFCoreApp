using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data;

public class KursKayit{
    [Key]
    [Display(Name ="Id")]
    public int KayitId { get; set; }

    public int KursId { get; set; }
    public Kurs Kurs { get; set; } = null!;

    public int OgrenciId { get; set; }
    public Ogrenci Ogrenci {get; set;} = null!;

    public DateTime KayitTarihi { get; set; }
}