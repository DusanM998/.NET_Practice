using Packt.Shared;
using static System.Console;

Person harry = new() { Name = "Harry" };
Person marry = new() { Name = "Marry" };
Person jill = new() { Name = "Jill" };

//Call instance method
Person baby1 = marry.ProcreateWith(harry);
baby1.Name = "Garry";

//Call static method
Person baby2 = Person.Procreate(harry, jill);

//Call an operator
Person baby3 = harry * marry;

WriteLine($"{harry.Name} has {harry.Children.Count} children.");
WriteLine($"{marry.Name} has {marry.Children.Count} children.");
WriteLine($"{jill.Name} has {jill.Children.Count} children.");
WriteLine(format: "{0}'s first child is named \"{1}\".",
    arg0: harry.Name,
    arg1: harry.Children[0].Name);

WriteLine($"5! is {Person.Factorial(5)}");

//Definisanje i obrada delegata
static void Harry_Shout(object? sender, EventArgs e)
{
    if(sender is null) return;
    Person p = (Person)sender;
    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
}

harry.Shout += Harry_Shout;

harry.Poke();
harry.Poke();
harry.Poke();
harry.Poke();

//non-generic lookup collection (Upotreba negenerickih tipova)
System.Collections.Hashtable lookupObject = new();

lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2; //lookup the value that has 2 as its key
WriteLine(format: "Key {0} has value: {1}",
    arg0: key,
    arg1: lookupObject[key]);

//lookup the value that has harry as its key
WriteLine(format: "Key {0} has the value: {1}",
    arg0: harry,
    arg1: lookupObject[harry]);

//Generic lookup collection (Upotreba generickih tipova)
Dictionary<int, string> lookupIntString = new();

lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");

key = 3;
WriteLine(format: "Key {0} has the value: {1}",
    arg0: key,
    arg1: lookupIntString[key]);

//Uporedjivanje objekata tokom sortiranja
Person?[] people =
{
  new() { Name = "Simon" },
  null,
  new() { Name = "Jenny" },
  new() { Name = "Adam" },
  new() { Name = null },
  new() { Name = "Richard" }
};

WriteLine("Initial list of people: ");
foreach(Person p in people)
{
    WriteLine($"  {(p is null ? "<null> Person" : p.Name ?? "<null> Name")}");
}

WriteLine("Use Person's IComparable implementation to sort: ");
Array.Sort(people);
foreach(Person p in people)
{
    WriteLine($"  {(p is null ? "<null> Person" : p.Name ?? "<null> Name")}");
}

//Poredjenje objekta pomocu posebne klase
WriteLine("Use PersonComparer's IComparer implementation to sort:");
Array.Sort(people, new PersonComparer());
foreach(Person p in people)
{
    WriteLine($"  {(p is null ? "<null> Person" : p.Name ?? "<null> Name")}");
}

//Definisanje tipova struct
DisplacementVector dv1 = new(3, 5);
DisplacementVector dv2 = new(-2, 7);
DisplacementVector dv3 = dv1 + dv2;

WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

//Nasledjivanje iz klasa
Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1985, month: 7, day: 15)
};
john.WriteToConsole();

//Prosiravanje klasa za dodavanje funkcionalnosti
john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2004, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");

//Zamena vrednosti clana
WriteLine(john.ToString());

//Razumevanje polomorfizma
Employee aliceInEmploye = new() { Name = "Alice", EmployeeCode = "AA123" };

Person aliceInPerson = aliceInEmploye;
aliceInEmploye.WriteToConsole();
WriteLine(aliceInEmploye.ToString());
WriteLine(aliceInPerson.ToString());

//Eksplicitna konverzija (casting)
if(aliceInPerson is Employee explicitAlice)
{
    WriteLine($"{nameof(aliceInPerson)} IS an Employee");
    //Employee explicitAlice = (Employee)aliceInPerson;
}

Employee? aliceAsEmploye = aliceInPerson as Employee; //Could be null
if(aliceInEmploye is not Employee)
{
    WriteLine($"{nameof(aliceInPerson)} AS an Employee");
}

//Nasledjivanje izuzetaka
try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch(PersonException ex)
{
    WriteLine(ex.Message);
}

//Primena statickih metoda za ponovnu upotrebu funkcionalnosti
string email1 = "pamela@test.com";
string email2 = "ian&test.com";

WriteLine("{0} is a valid e-mail address: {1}",
    arg0: email1,
    arg1: StringExtensions.IsValidEmail(email1));

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: StringExtensions.IsValidEmail(email2));

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: email1.IsValidEmail());

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: email2.IsValidEmail());