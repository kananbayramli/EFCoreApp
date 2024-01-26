using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data;

public class Ogretmen
{
    [Key]
    public int OgretmenId { get; set; }
    public string? Ad { get; set; }
    public string? Soyad { get; set; }
    public string? Email { get; set; }
    public string? Telefon { get; set; }
    public DateTime BaslamaTarihi { get; set; }
    public ICollection<Kurs> KursLar { get; set; } = new List<Kurs>();
}