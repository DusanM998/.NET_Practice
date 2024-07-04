using static System.Console;

//Vrednosni tip koji prihvata vrednost null

int thisCannotBeNull = 4;
//thisCannotBeNull = null; //Compile error

int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

//Deklarisanje promenljivih i parametara koji ne prihvataju vr. null
Address address = new();
address.Building = null;
address.Street = null;
address.City = "London";
address.Region = null;

//Provera vrednosti null
string authorName = null;

//the following throws a NullReferenceException
//int x = authorName.Length;

//instead of throwing an exception, null is assinged to y
int? y = authorName?.Length;

WriteLine($"y is null: {y is null}");

//result will be 3 if authorName?.Length is null
int result = authorName?.Length ?? 3;
WriteLine(result);

class Address
{
    public string? Building;
    public string Street = string.Empty;
    public string City = string.Empty;
    public string Region = string.Empty;
}