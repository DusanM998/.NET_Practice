using System.Xml.Serialization;

namespace Packt.Shared;

public class Person
{
    [XmlAttribute("fname")]
    public string? FirstName { get; set; }

    [XmlAttribute("lname")]
    public string? LastName { get; set; }

    [XmlAttribute("dob")]
    public DateTime DateOfBirth { get; set; }

    public HashSet<Person>? Childred { get; set; }

    public decimal Salary { get; set; }
    
    public Person() { }

    public Person(decimal initialSalary)
    {
        Salary = initialSalary;
    }
}