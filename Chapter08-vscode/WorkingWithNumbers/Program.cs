﻿using static System.Console;
using System.Numerics;

//Upotreba velikih celih brojeva

WriteLine("Working with large integers:");
WriteLine("-----------------------------------");

ulong big = ulong.MaxValue;
WriteLine($"{big,40:N0}");

BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
WriteLine($"{bigger,40:N0}");

//Upotreba kompleksnih brojeva

WriteLine("Working with complex numbers:");
Complex c1 = new(real: 4, imaginary: 2);
Complex c2 = new(real: 3, imaginary: 7);
Complex c3 = c1 + c2;

//Output using default ToString implementation
WriteLine($"{c1} added to {c2} is {c3}");

//Output using custom format
WriteLine("{0} + {1}i added to {2} + {3}i equals {4} + {5}i",
    c1.Real, c2.Imaginary,
    c2.Real, c2.Imaginary,
    c3.Real, c3.Imaginary);