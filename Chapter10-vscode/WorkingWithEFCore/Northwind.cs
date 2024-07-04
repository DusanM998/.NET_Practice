using Microsoft.EntityFrameworkCore; //DbContext, DbContextOptionsBuilder

using static System.Console;

namespace Packt.Shared;

//This manages the connection to the database
public class Northwind : DbContext
{
    //These properties map to tables in the database
    public DbSet<Category> Categories { get; set;  }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
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
        //Example of using FluentAPI instead of attributes
        //to limit the length of a CategoryName to under 15
        modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() //NOT NULL
            .HasMaxLength(15);

        if(ProjectConstants.DatabaseProvider == "SQLServer")
        {
            //Added to 'fix' the lack of decimal support in SQLServer
            modelBuilder.Entity<Product>()
                .Property(product => product.Cost)
                .HasConversion<double>();
        }

        //Global filter to remove discontinued products
        modelBuilder.Entity<Product>()
            .HasQueryFilter(p => !p.Discontinued);
    }
}