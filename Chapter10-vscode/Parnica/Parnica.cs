using System.ComponentModel.DataAnnotations; // [Required], [StringLength]
using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace Packt.Shared;

public class Parnica   
{
    public int ParnicaId { get; set; } //Primarni kljuc

    public DateTime DatumVremeOdrzavanja { get; set; }

    //public int ParnicaLokacijaId { get; set; }
    //public Lokacija? ParnicaLokacija { get; set; }


    /*public int SudijaId { get; set; }
    public Korisnik Sudija { get; set; }*/

    public string TipUstanove { get; set; }

    [Column(TypeName = "ntext")]
    public string IdentifikatorPostupka { get; set; }

    public int BrojSudnice { get; set; }

    /*public int TuzilacId { get; set; }
    public Kontakt Tuzilac { get; set; }

    public int TuzenikId { get; set; }
    public Kontakt Tuzenik { get; set; }*/

    //public int ZaduzeniAdvokatiId { get; set; }

    public virtual ICollection<Korisnik>? ZaduzeniAdvokati { get; set; }

    [Column(TypeName = "ntext")]
    public string Napomena { get; set; }

    /*public int TipPostupkaId { get; set; }
    public TipPostupka TipPostupka { get; set; }*/

    /*public Parnica()
    {
        ZaduzeniAdvokati = new HashSet<Korisnik>();
    }*/
}