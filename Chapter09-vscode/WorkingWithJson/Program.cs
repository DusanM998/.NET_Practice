﻿using System.Text.Json; //JsonSerializer
using System.Text.Json.Serialization; //[JsonInclude]
using WorkingWithJson;

using static System.Console;
using static System.Environment;
using static System.IO.Path;

Book cSharp10 = new(
    title: "C# 10 and .NET 6 - Modern Cross-platform Development")
{
    Author = "Mark J Price",
    PublishDate = new(year: 2021, month: 11, day: 9),
    Pages = 823,
    Created = DateTimeOffset.UtcNow,
};

JsonSerializerOptions options = new()
{
  IncludeFields = true, // includes all fields
  PropertyNameCaseInsensitive = true,
  WriteIndented = true,
  PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

options.Converters.Add(new DateOnlyConverter());
options.Converters.Add(new DateOnlyNullableConverter());

string filePath = Combine(CurrentDirectory, "book.json");

using(Stream fileStream = File.Create(filePath))
{
    JsonSerializer.Serialize<Book>(
        utf8Json: fileStream, value: cSharp10, options);
}

WriteLine("Written: {0:N0} bytes of JSON to {1}",
    arg0: new FileInfo(filePath).Length,
    arg1: filePath);

WriteLine();

//Display the serialized object graph
WriteLine(File.ReadAllText(filePath));

public class Book
{
    //Properties
    public string Title { get; set; }
    public string? Author { get; set; }

    //Fields
    [JsonInclude] //Include this field
    public DateOnly PublishDate;

    [JsonInclude]
    public DateTimeOffset Created;

    public ushort Pages;
    public Book(string title)
    {
        Title = title;
    }
}