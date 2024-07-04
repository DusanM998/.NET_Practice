namespace Packt.Shared;

public class ImmutablePerson
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
}

public record ImmutableVehicle
{
    public int Wheels { get; init; }
    public string? Color { get; init; }
    public string? Brand { get; init; }
}

//Rucno postavljanje zapisa kombinovanjem konstruktora i dekonstruktovanja
/*public record ImmutableAnimal
{
    public string Name { get; init; }
    public string Species { get; init; }
    
    public ImmutableAnimal(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public void Deconstruct(out string name, out string species)
    {
        name = Name;
        species = Species;
    }
}*/

//Sledeci kod definise zapis na isti nacin kao i prethodni
public record ImmutableAnimal(string Name, string Species);