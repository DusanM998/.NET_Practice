using System.ComponentModel.DataAnnotations.Schema; //[Column]

namespace Packt.Shared;

public class Category
{
    //Ovi properties mapiraju se u kolone u bazi podataka
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }

    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    //Definise svojstvo navigacije za povezane redove
    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        //Da bi omogucili developerima da dodaju proizvode u kategoriju
        //moramo inicijalizovati svojstvo navigacije na praznu kolekciju
        Products = new HashSet<Product>();
    }
}