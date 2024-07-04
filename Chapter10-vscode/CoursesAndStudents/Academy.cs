using Microsoft.EntityFrameworkCore;

using static System.Console;

namespace CoursesAndStudents;

public class Academy : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Course>? Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (ProjectConstants.DatabaseProvider == "SQLite") //This block is not necessary because I use SQLServer
        {
            string path = Path.Combine(
            Environment.CurrentDirectory, "Academy.db");

            WriteLine($"Using {path} database file.");

            optionsBuilder.UseSqlite($"Filename={path}");
        }
        else
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Academy;" +
                "Integrated Security=true;" +
                "MultipleActiveResultSets=true;";

            optionsBuilder.UseSqlServer(connection);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Fluent API validation rule
        modelBuilder.Entity<Student>()
            .Property(s => s.LastName).HasMaxLength(30).IsRequired();

        //Populate database with sample data

        Student alice = new()
        {
            StudentId = 1,
            FirstName = "Alice",
            LastName = "Jones"
        };
        Student bob = new()
        {
            StudentId = 2,
            FirstName = "Bob",
            LastName = "Smith"
        };
        Student cecilia = new()
        {
            StudentId = 3,
            FirstName = "Cecilia",
            LastName = "Ramirez"
        };
        Student pera = new()
        {
            StudentId = 4,
            FirstName = "Pera",
            LastName = "Peric"
        };

        Course csharp = new()
        {
            CourseId = 1,
            Title = "C# and .NET 6"
        };
        Course webdev = new()
        {
            CourseId = 2,
            Title = "Web Development"
        };
        Course python = new()
        {
            CourseId = 3,
            Title = "Python"
        };

        modelBuilder.Entity<Student>()
            .HasData(alice, bob, cecilia, pera);

        modelBuilder.Entity<Course>()
            .HasData(csharp, webdev, python);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity(e => e.HasData(
                //All students signed up for C# course
                new { CoursesCourseId = 1, StudentsStudentId = 1 },
                new { CoursesCourseId = 1, StudentsStudentId = 2 },
                new { CoursesCourseId = 1, StudentsStudentId = 3 },
                new { CoursesCourseId = 1, StudentsStudentId = 4 },
                //Bob and Pera signed up for Web Dev
                new { CoursesCourseId = 2, StudentsStudentId = 2 },
                new { CoursesCourseId = 2, StudentsStudentId = 4 },
                //Only Cecilia signed up for Python
                new { CoursesCourseId = 3, StudentsStudentId = 3 }
            ));
    }
}