using static System.Console;
using System.Collections.Immutable;

//WorkingWithLists();
//WorkingWithDictionaries();
//WorkingWithQueues();
WorkingWithPriorityQueues();

static void Output(string title, IEnumerable<string> collection)
{
    WriteLine(title);
    foreach(string item in collection)
    {
        WriteLine($" {item}");
    }
}

//Upotreba lista
static void WorkingWithLists()
{
    //Simple syntax for creating a list and adding 3 items
    List<string> cities = new();
    cities.Add("London");
    cities.Add("Paris");
    cities.Add("Milan");

    //Alternative syntax that is converted by the compiler into
    //the three Add method calls above

    List<string> cities1 = new() {"New York", "Los Angeles", "Berlin"};

    //Alternative syntax that passes an array of string values to AddRange method
    List<string> cities2 = new();
    cities2.AddRange(new[] { "Moscow", "Madrid", "Boston" });

    Output("Initial list", cities);

    WriteLine($"The first city is: {cities[0]}.");
    WriteLine($"The last city is: {cities[2]}.");

    cities.Insert(0, "Sydney");

    Output("After inserting city Sydney at index 0: ", cities);

    cities.RemoveAt(1);
    cities.Remove("Milan");

    Output("After removing two cities: ", cities);

    //Upotreba nepromenljvih lokacija
    ImmutableList<string> immutableCities = cities.ToImmutableList();
    ImmutableList<string> newList = immutableCities.Add("Rio");

    Output("Immutable list of cities: ", immutableCities);
    Output("New list of cities: ", newList);
}

//Upotreba recnika
static void WorkingWithDictionaries()
{
    Dictionary<string, string> keywords = new();

    //Add using parametres
    keywords.Add(key: "int", value: "32-bit integer data type");

    //Add using positional parametres
    keywords.Add("long", "64-bit integer data type");
    keywords.Add("float", "Single precision floating point number");

    //Alternative syntax; compiler converts this to calls to Add method
    Dictionary<string, string> keywords1 = new()
    {
        { "int", "32-bit integer data type" },
        { "long", "64-bit integer data type" },
        { "float", "Single precision floating point number" },
    };

    //Alternative syntax; compiler converts this to calls to Add method
    Dictionary<string, string> keywords2 = new()
    {
        ["int"] = "32-bit integer data type",
        ["long"] = "64-bit integer data type",
        ["float"] = "Single precision floating point number"
    };

    Output("Dictionary keys: ", keywords.Keys);
    Output("Dictionary values:", keywords2.Values);

    WriteLine("Keywords and their definitions: ");
    foreach(KeyValuePair<string, string> item in keywords1)
    {
        WriteLine($"  {item.Key}: {item.Value}");
    }

    //lookup a value using a key
    string key = "long";
    WriteLine($"The definition of {key} is {keywords[key]}");
}


//Upotreba redova cekanja
static void WorkingWithQueues()
{
    Queue<string> coffee = new();

    coffee.Enqueue("Damir"); //front of queue
    coffee.Enqueue("Andrea");
    coffee.Enqueue("Milan");
    coffee.Enqueue("David");
    coffee.Enqueue("Irina");

    Output("Initial queue from front to back: ", coffee);

    //Server handles next person in the queue
    string served = coffee.Dequeue();
    WriteLine($"Served: {served}.");

    //Server handles the next person in queue
    served = coffee.Dequeue();
    WriteLine($"Served: {served}.");

    Output("Current queue from front to back: ", coffee);

    WriteLine($"{coffee.Peek()} is next in line.");

    Output("Current queue from front to back: ", coffee);
}

//Genericki metod. Mogu se specifikovati 2 tipa
//upotrebljena u torkama koji se prosledjuju kao kolekcija
static void OutputPQ<TElement, TPriority>(string title,
    IEnumerable<(TElement Element, TPriority Priority)> collection)
{
    WriteLine(title);
    foreach((TElement, TPriority) item in collection)
    {
        WriteLine($"  {item.Item1}: {item.Item2}");
    }
}

static void WorkingWithPriorityQueues()
{
    PriorityQueue<string, int> vaccine = new();

    vaccine.Enqueue("Pamela", 1);
    vaccine.Enqueue("Rebecca", 3);
    vaccine.Enqueue("Juliet", 2);
    vaccine.Enqueue("Ian", 1);

    OutputPQ("Current queue for vaccination: ", vaccine.UnorderedItems);

    WriteLine($"{vaccine.Dequeue()} has been vaccinated.");
    WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

    OutputPQ("Current queue after vaccination: ", vaccine.UnorderedItems);

    WriteLine($"{vaccine.Dequeue()} has been vaccinated.");

    vaccine.Enqueue("Mark", 2);
    WriteLine($"{vaccine.Peek()} will be next to be vaccinated"); //Peek vraca objekat sa pocetka reda bez brisanja
}