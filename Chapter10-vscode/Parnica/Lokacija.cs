using System.ComponentModel.DataAnnotations; // [Required], [StringLength]

namespace Packt.Shared;

public class Lokacija
{
    public int LokacijaId { get; set; } //Primarni kljuc

    [Required]
    [StringLength(20)]
    public string LokacijaNaziv { get; set; }

    /*public int ParnicaID { get; set; }
    public Parnica Parnica { get; set; }*/
}