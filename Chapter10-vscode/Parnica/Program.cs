using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Packt.Shared;

using static System.Console;

WriteLine($"Using {ProjectConstants.DatabaseProvider} database provider.");

using(ParnicaContext pc = new())
{
    bool deleted = await pc.Database.EnsureDeletedAsync();
    WriteLine($"Database deleted: {deleted}");

    bool created = await pc.Database.EnsureCreatedAsync();
    WriteLine($"Database created: {created}.");

    WriteLine("SQL Script used to create database: ");
    WriteLine(pc.Database.GenerateCreateScript());

    /*foreach(Parnica p in pc.Parnice.Include(a => a.ZaduzeniAdvokati))
    {
        WriteLine("{0} ")
    }*/
}

//AddLokacija(lokacijaId:1, nazivLokacije: "Nis");
//ListLocations();

/*static void ListLocations()
{
    using(ParnicaContext db = new())
    {
        WriteLine("{0,-3} {1,-35}",
            "ID", "Naziv lokacija");
        
        foreach(Lokacija l in db.Lokacija)
        {
            WriteLine("{0,-3} {1,-35}", l.LokacijaId, l.LokacijaNaziv);
        }
    }
}*/

