using static System.Console;
using System.Text.RegularExpressions;

//Provera cifara unetih kao tekst
Write("Enter your age: ");
string? input = ReadLine();

Regex ageChecker = new(@"^\d{1,3}$");

if(ageChecker.IsMatch(input))
{
    WriteLine("Thank you!");
}
else
{
    WriteLine($"This is not a valid age: {input}");
}

//Razdvajanje kompleksnog znakovnog niza razdvojenog zarezima
string films = "\"Monsters, Inc.\",\"I, Tonya\",\"Lock, Stock and Two Smoking Barrels\"";

WriteLine($"Movies to split: {films}");

string[] filmsDumb = films.Split(',');

WriteLine("Splitting with string.Split() method");
foreach(string film in filmsDumb)
{
    WriteLine(film);
}
WriteLine();

//Razdvajanje pomocu regularnog izraza

//Iskazi za def. reg. izr. za razdvajanje i pisanje naslova
Regex csv = new(
  "(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");

MatchCollection filmsSmart = csv.Matches(films);

WriteLine("Splitting with regular expression.");
foreach(Match film in filmsSmart)
{
    WriteLine(film.Groups[2].Value);
}