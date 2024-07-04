using static System.Console;

//Niz stringova je sekvenca koja implementira interfejs IEnumerable<string>
string[] names = new[] { "Michalel", "Pam", "Jim", "Dwight",
    "Angela","Kevin", "Toby", "Creed"};

WriteLine("Deferred execution");

//Question: Which names end with an M?
// (Written using a LINQ extension method)
var query1 = names.Where(name => name.EndsWith("m"));

//Answer returned as an array of strings containg specified names
string[] result1 = query1.ToArray();

//Question: Which names end with an M?
// (Written using a LINQ query comperhension syntax)
var query2 = from name in names where name.EndsWith("m") select name;

//Answer returned as a list of strings containing specified names
List<string> result2 = query2.ToList();

//Answer returned as we enumerate over the results
foreach(string name in query1)
{
    WriteLine(name);
    names[2] = "Jimmy"; //Changes Jim to Jimmy
    //On the second iteration Jimmy does not end with M
}

WriteLine("Writing queries:");

//Upotreba imenovanog metoda
//var query = names.Where(new Func<string, bool>(NameLongerThanFour));

//Pojednostavljenje prethodnog koda uklanjanjem
//eksplicitnog instanciranja delegata
//var query = names.Where(NameLongerThanFour);

//Upotreba lambda izraza
IOrderedEnumerable<string> query = names
    .Where(name => name.Length > 4)
    .OrderBy(name => name.Length)
    .ThenBy(name => name);

foreach(string item in query)
{
    WriteLine(item);
}

WriteLine("Flitering by type.");

List<Exception> exceptions = new()
{
    new ArgumentException(),
    new SystemException(),
    new IndexOutOfRangeException(),
    new InvalidOperationException(),
    new NullReferenceException(),
    new InvalidCastException(),
    new OverflowException(),
    new DivideByZeroException(),
    new ApplicationException()
};

IEnumerable<ArithmeticException> arithmeticExceptionsQuery =
    exceptions.OfType<ArithmeticException>();

foreach(ArithmeticException exception in arithmeticExceptionsQuery)
{
    WriteLine(exception);
}

static bool NameLongerThanFour(string name)
{
    return name.Length > 4;
}