using static System.Console;

static double Add(double a, double b)
{
    return a + b;
}

double a = 4.5;
double b = 2.5;
double result = Add(a, b);
WriteLine($"{a} + {b} = {result}");

WriteLine("Press ENTER to end the app!");
ReadLine(); //wait for user to press ENTER