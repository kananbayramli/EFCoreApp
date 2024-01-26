namespace EFCoreApp.Models;

public class KursViewModel{

    public int KursId { get; set; }
    public string? Baslik { get; set; }
    //Burada int deyeri null etme sebebi evvelki migrationu silmek , datalari silmek yerine onlara NULL deyer vere bilmekdir. ? qoymasaq bize Foreign key constrint erroru gelecek. 
    public int? OgretmenId { get; set; }

}