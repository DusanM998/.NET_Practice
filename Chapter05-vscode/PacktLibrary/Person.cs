using System;
using static System.Console;

namespace Packt.Shared;

public partial class Person : Object
{
    //fields
    public string Name;
    public DateTime DateOfBirth;
    public WondersOfTheAncientWorld FavoriteAncientWorld;
    public WondersOfTheAncientWorld BucketList;
    //public List<Person> Children = new List<Person>(); //For older versions of .NET
    public List<Person> Children = new();

    //Constant fields
    public const string Species = "Homo Sapiens";

    //Read-only fields
    public readonly string HomePlanet = "Planet Earth";

    public readonly DateTime Instantiated;

    //constructors
    public Person()
    {
        //Set the default values for fields
        //including read-only fields
        Name = "Unknown";
        Instantiated = DateTime.Now;
    }

    public Person(string initialName, string homePlanet)
    {
        Name = initialName;
        HomePlanet = homePlanet;
        Instantiated = DateTime.Now;
    }

    //methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth}");
    }

    public string GetOrigin()
    {
        return $"{Name} was born on {HomePlanet}";
    }

    public (string, int) GetFruit()
    {
        return ("Apples", 5);
    }

    public (string Name, int Number) GetNamedFruit()
    {
        return (Name: "Apples", Number: 5);
    }

    //Deconstruct (Rastavlja objekat na delove)
    public void Deconstruct(out string name, out DateTime dob)
    {
        name = Name;
        dob = DateOfBirth;
    }

    public void Deconstruct(out string name, out DateTime dob, out WondersOfTheAncientWorld fav)
    {
        name = Name;
        dob = DateOfBirth;
        fav = FavoriteAncientWorld;
    }

    //Definisanje i prosledjivanje parametara u metode
    public string SayHello()
    {
        return $"{Name} says 'Hello!'";
    }

    public string SayHello(string name)
    {
        return $"{Name} says 'Hello {name}!'";
    }

    //Prosledjivanje opcionih i imenovanih parametara
    public string OptionalParameters(
        string command = "Run!",
        double number = 0.0,
        bool active = true
    )
    {
        return string.Format(format: "Command is {0}, number is {1}, active is {2}",
            arg0: command,
            arg1: number,
            arg2: active);
    }

    //Kontrolisanje nacina prosledjivanja parametara
    public void PassingParemetres(int x, ref int y, out int z)
    {
        //out parametres cannot have a default
        //AND must be initialized inside the method
        z = 99;

        //increment each parameter
        x++;
        y++;
        z++;
    }
}