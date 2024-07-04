using System.ComponentModel.DataAnnotations.Schema; //[Column]
using System.ComponentModel.DataAnnotations; //[Required], [StringLength]

namespace Packt.Shared;

public class Product
{   
    //Primarni kljuc
    public int ProductId { get; set; }

    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null;

    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; } //property name != column name

    [Column("UnitsInStock")]
    public short? Stock { get; set; }

    public bool Discontinued { get; set; }

    //Ova dva propertija definisu strani(foreign) key
    //vezu u tabeli Category
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null;
}