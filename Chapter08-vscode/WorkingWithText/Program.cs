using static System.Console;

//Preuzimanje duzine znakovnog niza

string city = "London";
WriteLine($"{city} is {city.Length} characters long.");

//Preuzimanje karaktera znakovnog niza
WriteLine($"First char is {city[0]} and the third is {city[2]}");

//Razdvajanje znakovnog niza
string cities = "Paris,Tehran,Chennai,Sydney,New York,Medellín";

string[] citiesArray = cities.Split(',');

WriteLine($"There are {citiesArray.Length} items in the array.");
foreach(string item in citiesArray)
{
    WriteLine(item);
}

//Preuzimanje dela znakovnog niza
string fullName = "Alan Jones";
int indexOfTheSpace = fullName.IndexOf(' ');

string firstName = fullName.Substring(
    startIndex: 0, length: indexOfTheSpace);

string lastName = fullName.Substring(
    startIndex: indexOfTheSpace + 1);

WriteLine($"Original: {fullName}");
WriteLine($"Swapped: {lastName}, {firstName}");

//Provera sadrzaja znakovnog niza
string company = "Microsoft";
bool startsWithM = company.StartsWith("M");
bool containsN = company.Contains("N");

WriteLine($"Text: {company}");
WriteLine($"Starts with M: {startsWithM}, contains an N: {containsN}");

//String.Join -> Nadovezuje jednu ili vise promenljivih string
//koristeci razmak izmedju svake od njih
string recombined = string.Join(" => ", citiesArray);
WriteLine(recombined);

//Interpolirana sintaksa formatiranja string vrednosti
string fruit = "Apples";
decimal price = 0.39M;
DateTime when = DateTime.Today;

WriteLine($"Interpolated: {fruit} cost {price:C} on {when:dddd}");

WriteLine(string.Format("string.Format: {0} cost {1:C} on {2:dddd}",
    arg0: fruit,
    arg1: price,
    arg2: when));