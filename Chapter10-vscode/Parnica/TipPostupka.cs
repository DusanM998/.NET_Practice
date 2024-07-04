using System.ComponentModel.DataAnnotations; // [Required], [StringLength]

namespace Packt.Shared;

public class TipPostupka
{
    public int TipPostupkaId { get; set; } //Primarni kljuc

    [Required]
    [StringLength(20)]
    public string TipPostupkaNaziv { get; set; }

    //public ICollection<Parnica>? Parnice { get; set; }
}