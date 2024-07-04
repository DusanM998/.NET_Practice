using System.ComponentModel.DataAnnotations; // [Required], [StringLength]

namespace Packt.Shared;

public class Korisnik   
{
    public int KorisnikId { get; set; } //Primarni kljuc

    [Required]
    [StringLength(20)]
    public string KorisnikIme { get; set; }

    [Required]
    [StringLength(20)]
    public string KorisnikPrezime { get; set; }

    public string Uloga { get; set; }

    public ICollection<Parnica> Parnice { get; set; }
}