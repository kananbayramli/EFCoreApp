using System.ComponentModel.DataAnnotations;

namespace EFCoreApp.Data;

public class Ogrenci{

    [Key]
    [Display(Name ="Id")]
    public int OgrenciId { get; set; }

    [Display(Name ="Ad")]
    public string? OgrenciAd { get; set; }
    [Display(Name ="Soyad")]
    public string? OgrenciSoyad { get; set; }
    public string? Email { get; set; }
    public string? Telefon { get; set; }
}