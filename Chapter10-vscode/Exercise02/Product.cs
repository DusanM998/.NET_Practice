using System.ComponentModel.DataAnnotations; // [Required], [StringLenght]
using System.ComponentModel.DataAnnotations.Schema; // [Column]

namespace Packt.Shared;

public class Product
{
    public int ProductId { get; set; }

    [Required]
    [StringLength(40)]
    public string? ProductName { get; set; }

    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }

    [Column("UnitsInStock")]
    public short? Stock { get; set; }

    public bool Discontinued { get; set; }

    //Ova dva propertija definisu vezu stranog kljuca
    //Ka tabeli Kategorija
    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}