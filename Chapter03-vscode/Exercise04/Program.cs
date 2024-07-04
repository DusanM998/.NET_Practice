using static System.Console;

Write("Enter a number beweeen 0 and 255:");
string? n1 = ReadLine();

Write("Enter a number beweeen 0 and 255:");
string? n2 = ReadLine();

try
{
    byte a = byte.Parse(n1);
    byte b = byte.Parse(n2);

    int result = a / b;

    WriteLine($"{a} divided by {b} is {result}");
}
catch(Exception ex)
{
    WriteLine($"{ex.GetType ().Name}: {ex.Message}");
}