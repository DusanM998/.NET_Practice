using Microsoft.EntityFrameworkCore; //DbContext

using static System.Environment;
using static System.IO.Path;

namespace Packt.Shared;

//This manages connection to the database
public class Northwind : DbContext
{
    //These properties map to tables in the database
    public DbSet<Customer>? Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = Combine(CurrentDirectory, "Northwind.db");

        optionsBuilder.UseSqlite($"Filename={path}");
    }
}