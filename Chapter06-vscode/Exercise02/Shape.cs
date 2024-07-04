using static System.Console;

namespace Packt.Shared;

public abstract class Shape
{
    //fields
    protected double height;
    protected double width;

    //properties
    public virtual double Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
        }
    }

    public virtual double Width
    {
        get
        {
            return width;
        }
        set
        {
            width = value;
        }
    }

    //Area svojstvo mora biti implementirano od strane potklasa
    //kao read-only svojstvo (jer se razlikuje racunanje povrsine svakog od oblika)
    public abstract double Area { get; }
}