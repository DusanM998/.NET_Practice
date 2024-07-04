using System.ComponentModel.DataAnnotations; // [Required], [StringLength]

namespace Packt.Shared;

public class Kompanija   
{
    public int KompanijaId { get; set; } //Primarni kljuc

    [Required]
    [StringLength(20)]
    public string KompanijaNaziv { get; set; }

    [Required]
    [StringLength(50)]
    public string KompanijaAdresa { get; set; }

    //public ICollection<Kontakt>? Kontakti { get; set; }
}