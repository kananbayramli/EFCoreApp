using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data;

public class Kurs{

    public int KursId { get; set; }

    [Display(Name ="Kurs")]
    public string? Baslik { get; set; }


    //Burada int deyeri null etme sebebi evvelki migrationu silmek , datalari silmek yerine onlara NULL deyer vere bilmekdir. ? qoymasaq bize Foreign key constrint erroru gelecek. 
    public int? OgretmenId { get; set; }
    public Ogretmen Ogretmen { get; set; } = null!;

    public ICollection<KursKayit> KursKayitLari { get; set; } = new List<KursKayit>();
}