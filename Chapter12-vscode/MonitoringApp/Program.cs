using static System.Console;

using Packt.Shared; // Recorder

//Pracenje performansi i memorije pomocu dijagnostike
WriteLine("Processing. Please wait...");
Recorder.Start();

// Simulate a process that requires some memory resources...
int[] largeArrayOfInits = Enumerable.Range(
    start: 1, count: 10_000).ToArray();

//...and takes some time to complete
Thread.Sleep(new Random().Next(5, 10) * 1000);

Recorder.Stop();

//Merenje efikasnosti obrade znakovnih nizova
int[] numbers = Enumerable.Range(
    start: 1, count: 50_000).ToArray();

WriteLine("Using string with +");
Recorder.Start();
string s = string.Empty;
for (int i = 0; i < numbers.Length; i++)
{
    s += numbers[i] + ", ";
}
Recorder.Stop();

WriteLine("Using StringBuilder");
Recorder.Start();
System.Text.StringBuilder builder = new();
for (int i = 0; i < numbers.Length; i++)
{
    builder.Append(numbers[i]);
    builder.Append(", ");
}
Recorder.Stop();