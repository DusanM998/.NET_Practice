using static System.Console;
using static System.Environment;
using static System.IO.Path;

using System.Xml.Serialization; //XmlSerializer
using Packt.Shared; //Person
using NewJson = System.Text.Json.JsonSerializer;

//Serijalizacija upotrebom XML formata

//Create an object graph
List<Person> people = new()
{
    new(30000M)
    {
        FirstName = "Alice",
        LastName = "Smith",
        DateOfBirth = new(1995, 3, 14)
    },
    new(40000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(1994, 12, 5)
    },
    new(20000M)
    {
        FirstName = "Charlie",
        LastName = "Fox",
        DateOfBirth = new(1984, 11, 23),
        Childred = new()
        {
            new(0M)
            {
                FirstName = "Sally",
                LastName = "Fox",
                DateOfBirth = new(2002, 7, 12)
            }
        }
    }
};

//Kreiranje objekta koji ce formatirati listu Osoba kao XML
XmlSerializer xs = new(people.GetType());

//Kreiranje fajla za upis
string path = Combine(CurrentDirectory, "people.xml");

using(FileStream stream = File.Create(path))
{
    //Serialize the object graph to the stream
    xs.Serialize(stream, people);
}

WriteLine("Written {0:N0} bytes of XML to {1}",
    arg0: new FileInfo(path).Length,
    arg1: path);
WriteLine();

//Display the serialized object graph
WriteLine(File.ReadAllText(path));

//Deserijalizacija XML fajla
using(FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    //Deserialize and cast the object graph into a List of Person
    List<Person> loadedPeople = xs.Deserialize(xmlLoad) as List<Person>;

    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.",
                p.LastName, p.Childred?.Count ?? 0);
        }
    }
}

//Serijalizacija pomocu JSON formata

//Create a file to writing to
string jsonPath = Combine(CurrentDirectory, "people.json");

using(StreamWriter jsonStream = File.CreateText(jsonPath))
{
    //Create an object that will format as JSON
    Newtonsoft.Json.JsonSerializer jss = new();

    //Serialize the object graph into a string
    jss.Serialize(jsonStream, people);
}
WriteLine();
WriteLine("Written {0:N0} bytes of JSON to: {1}",
    arg0: new FileInfo(jsonPath).Length,
    arg1: jsonPath);

//Display the serialized object graph
WriteLine(File.ReadAllText(jsonPath));

//Obrada JSON fajlova visokih performansi
using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
    //Deserialize object graph into a List of Person
    List<Person>? loadedPeople = await NewJson.DeserializeAsync(
        urf8Json: jsonLoad, returnType: typeof(List<Person>)) as List<Person>;

    if(loadedPeople is not null)
    {
        foreach(Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.",
                p.LastName, p.Childred?.Count ?? 0);
        }
    }
}