using static System.Console;
using System.Text.RegularExpressions;

//Trazi od korisnika da unese reg. izr. a zatim nesto drugo
//i uporedi ta dva unosa trazeci podudarnost, sve dok korisnik ne pritisne Esc

WriteLine("The default regular expression checks for at least one digit.");

do
{
    Write("Enter a regular expression (or press ENTER to use the default): ");
    string? regExp = ReadLine();

    if (string.IsNullOrWhiteSpace(regExp))
    {
        regExp = @"^\d+$";
    }

    Write("Enter some input: ");
    string? input = ReadLine();

    Regex r = new(regExp);

    WriteLine($"{input} matches {regExp}: {r.IsMatch(input)}");

    WriteLine("Press ESC to end or any key to try again.");
}
while (ReadKey().Key != ConsoleKey.Escape);