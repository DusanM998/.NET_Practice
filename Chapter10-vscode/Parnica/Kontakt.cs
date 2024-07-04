using System.ComponentModel.DataAnnotations; // [Required], [StringLength], [EmailAddress]
using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace Packt.Shared;

public class Kontakt
{
    public int KontaktId { get; set; } //Primarni kljuc

    public string? KontaktIme { get; set; }

    [Column("Telefon1")]
    public string Telefon1 { get; set; }

    [Column("Telefon2")]
    public string Telefon2 { get; set; }

    public string Adresa { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string Flag { get; set; }

    [Column(TypeName = "ntext")]
    public string Zanimanje { get; set; }

    public int PripadnostKompanijiId { get; set; }

    //public Kompanija PripadnostKompaniji { get; set; }

    //public ICollection<Kompanija>? Kompanije { get; set; }

    //public ICollection<Parnica>? Parnice { get; set; }
}