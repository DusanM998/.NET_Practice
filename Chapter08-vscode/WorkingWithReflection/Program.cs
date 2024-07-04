using static System.Console;
using System.Reflection; //Assembly
using System.Runtime.CompilerServices; //to use CompilerGeneratedAttribute
using Packt.Shared; //for CoderAttribute


WriteLine("Assembly metadata: ");
Assembly? assembly = Assembly.GetEntryAssembly();
if(assembly is null)
{
    WriteLine("Failed to get entry assembly.");
    return;
}

WriteLine($"  Full name: {assembly.FullName}");
WriteLine($"  Location: {assembly.Location}");

IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();

WriteLine($"  Assembly-level attributes: ");
foreach(Attribute a in attributes)
{
    WriteLine($"   {a.GetType()}");
}

AssemblyInformationalVersionAttribute? version = assembly
    .GetCustomAttribute<AssemblyInformationalVersionAttribute>();
WriteLine($"   Version: {version?.InformationalVersion}");

AssemblyCompanyAttribute? company = assembly
    .GetCustomAttribute<AssemblyCompanyAttribute>();
WriteLine($"   Company: {company?.Company}");

WriteLine();
WriteLine($"* Types: ");
Type[] types = assembly.GetTypes();

foreach(Type type in types)
{
    //Optional exercise for compiler-generated code
    CompilerGeneratedAttribute? compilerGenerated =
        type.GetCustomAttribute<CompilerGeneratedAttribute>();
    if(compilerGenerated != null) continue; //skip to next item

    WriteLine();
    WriteLine($"Type: {type.FullName}");
    MemberInfo[] members = type.GetMembers();

    foreach(MemberInfo member in members)
    {
        WriteLine("{0}: {1} ({2})",
            arg0: member.MemberType,
            arg1: member.Name,
            arg2: member.DeclaringType?.Name);

        IOrderedEnumerable<CoderAttribute> coders =
            member.GetCustomAttributes<CoderAttribute>()
            .OrderByDescending(c => c.LastModified);

        foreach(CoderAttribute coder in coders)
        {
            WriteLine("-> Modified by: {0} on {1}",
                arg0: coder.Coder,
                arg1: coder.LastModified.ToShortDateString());
        }
    }
}

class Animal
{
    [Coder("Dusan Milojkovic", "06 May 2023")]
    [Coder("Mark Price", "22 August 2022")]
    public void Speak()
    {
        WriteLine("Woooof...");
    }
}