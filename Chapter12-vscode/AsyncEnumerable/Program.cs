﻿using static System.Console;

//Upotreba kljucne reci aync u tokovima
await foreach(int number in GetNumbersAsync())
{
    WriteLine($"Number: {number}");
}

async static IAsyncEnumerable<int> GetNumbersAsync()
{
    Random r = new();

    // Simulate work
    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(0, 1001);

    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(0, 1001);

    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(0, 1001);
}