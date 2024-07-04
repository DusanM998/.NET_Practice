using static System.Console;
using System.Text;

//Kodiranje znakovnih nizova kao nizova bajtova
WriteLine("Encodings: ");
WriteLine("[1] ASCII");
WriteLine("[2] UTF-7");
WriteLine("[3] UTF-8");
WriteLine("[4] UTF-16");
WriteLine("[5] UTF-32");
WriteLine("[any other key] Default");

//Choose an encoding
Write("Press a number to choose an encoding: ");
ConsoleKey number = ReadKey(intercept: false).Key;
WriteLine();
WriteLine();

Encoding encoder = number switch
{
    ConsoleKey.D1 or ConsoleKey.NumPad1 => Encoding.ASCII,
    ConsoleKey.D2 or ConsoleKey.NumPad2 => Encoding.UTF7,
    ConsoleKey.D3 or ConsoleKey.NumPad3 => Encoding.UTF8,
    ConsoleKey.D4 or ConsoleKey.NumPad4 => Encoding.Unicode,
    ConsoleKey.D5 or ConsoleKey.NumPad5 => Encoding.UTF32,
    _ => Encoding.Default
};

//Define a string to encode
string message = "Café cost: £4.39";

//Encode the string into a byte array
byte[] encoded = encoder.GetBytes(message);

//Check how many bytes encoding needed
WriteLine("{0} uses {1:N0} bytes.",
    encoder.GetType().Name, encoded.Length);

//Enumerate each byte
WriteLine($"BYTE  HEX  CHAR");
foreach(byte b in encoded)
{
    WriteLine($"{b,4} {b.ToString("X"),4} {(char)b,5}");
}

//Decode the byte array back into a string and display it
string decoded = encoder.GetString(encoded);
WriteLine(decoded);