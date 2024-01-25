using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data;

public class Kurs{

    public int KursId { get; set; }

    [Display(Name ="Kurs")]
    public string? Baslik { get; set; }

    public ICollection<KursKayit> KursKayitLari { get; set; } = new List<KursKayit>();
}