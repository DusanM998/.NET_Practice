using Microsoft.EntityFrameworkCore; //DbContext, DbContextOptionsBuilder

using static System.Console;

namespace Packt.Shared;

public class Northwind : DbContext
{
    //Ovi propertiji se mapiraju u tabele u bazi podataka
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (ProjectConstants.DatabaseProvider == "SQLite") //This block is not necessary because I use SQLServer
        {
            string path = Path.Combine(
            Environment.CurrentDirectory, "Northwind.db");

            WriteLine($"Using {path} database file.");

            optionsBuilder.UseSqlite($"Filename={path}");
        }
        else
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Northwind;" +
                "Integrated Security=true;" +
                "MultipleActiveResultSets=true;";

            optionsBuilder.UseSqlServer(connection);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Primer koriscenja Fluent API-ja umesto atributa
        //za limitiranje duzine imena kategorije ispod 20 karaktera
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired()
            .HasMaxLength(20);
    }
}