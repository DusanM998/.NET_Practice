using static System.Console;

using Packt.Shared;

Rectangle r = new(height: 3, width: 4.5);
WriteLine($"Rectangle Height: {r.Height}, Width: {r.Width}, and Area: {r.Area}");

Square s = new(6);
WriteLine($"Square Height: {s.Height}, Width: {s.Width}, and Area: {s.Area}");

Circle c = new(radius: 2.5);
WriteLine($"Circle Height: {c.Height}, Width: {c.Width}, and Area {c.Area}");