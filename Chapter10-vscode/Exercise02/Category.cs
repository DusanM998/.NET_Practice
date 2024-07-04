using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace Packt.Shared;

public class Category
{
    //Ovi propertiji se mapiraju u kolone baze podataka
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    //Defines a navigation property for related rows
    //Veza jedan prema vise (Kategorija moze imati vise Proizvoda)
    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        //Da bi omogucilo developerima da dodaju Proizvod u Kategoriju
        //najpre moramo inicijalizovati navigacioni property na praznu listu
        Products = new HashSet<Product>();
    }
}