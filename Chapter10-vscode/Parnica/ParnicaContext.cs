using Microsoft.EntityFrameworkCore; // DbContext, DbContextOptionsBuilder

using static System.Console;

namespace Packt.Shared;

public class ParnicaContext : DbContext
{
    //Ovi propertiji se mapiraju u tabele u bazi podataka
    public DbSet<Kompanija>? Kompanije { get; set; }
    public DbSet<Kontakt>? Kontakti { get; set; }

    public DbSet<Korisnik>? Korisnici { get; set; }

    public DbSet<Lokacija>? Lokacije { get; set; }
    public DbSet<Parnica>? Parnice { get; set; }
    public DbSet<TipPostupka>? TipoviPostupaka { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (ProjectConstants.DatabaseProvider == "SQLite")
        {
            string path = Path.Combine(
            Environment.CurrentDirectory, "Parnica.db");

            WriteLine($"Using {path} database file.");

            optionsBuilder.UseSqlite($"Filename={path}");
        }
        else
        {
            string connection = "Data Source=.;" +
                "Initial Catalog=Parnica;" +
                "Integrated Security=true;" +
                "MultipleActiveResultSets=true;";

            optionsBuilder.UseSqlServer(connection);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kontakt>()
            .Property(kontakt => kontakt.KontaktIme)
            .IsRequired()
            .HasMaxLength(20);

        modelBuilder.Entity<Lokacija>()
            .Property(lokacija => lokacija.LokacijaNaziv)
            .IsRequired()
            .HasMaxLength(20);

        modelBuilder.Entity<TipPostupka>()
            .Property(tipPostupka => tipPostupka.TipPostupkaNaziv)
            .IsRequired()
            .HasMaxLength(20);

        //Populate database with sample data

        Kompanija kompanija1 = new()
        {
            KompanijaId = 1,
            KompanijaNaziv = "Kompanija1",
            KompanijaAdresa = "Adresa1"
        };
        Kompanija kompanija2 = new()
        {
            KompanijaId = 2,
            KompanijaNaziv = "Kompanija2",
            KompanijaAdresa = "Adresa2"
        };
        Kompanija kompanija3 = new()
        {
            KompanijaId = 3,
            KompanijaNaziv = "Kompanija3",
            KompanijaAdresa = "Adresa3"
        };

        Kontakt kontakt1 = new()
        {
            KontaktId = 1,
            KontaktIme = "Kontakt",
            Telefon1 = "123456",
            Telefon2 = "123789",
            Adresa = "Adr",
            Email = "kontakt@gmail.com",
            Flag = "Pravno",
            Zanimanje = "zanimanje",
        };
        Kontakt kontakt2 = new()
        {
            KontaktId = 2,
            KontaktIme = "Kontakt2",
            Telefon1 = "1234567",
            Telefon2 = "234569",
            Adresa = "Adr2",
            Email = "kontakt2@gmail.com",
            Flag = "Pravno",
            Zanimanje = "zanimanje2",
        };
        Kontakt kontakt3 = new()
        {
            KontaktId = 3,
            KontaktIme = "Kontakt3",
            Telefon1 = "7945612",
            Telefon2 = "159753",
            Adresa = "Adr3",
            Email = "kontakt3@gmail.com",
            Flag = "Pravno",
            Zanimanje = "zanimanje",
        };

        Korisnik korisnik1 = new()
        {
            KorisnikId = 1,
            KorisnikIme = "Korisnik1",
            KorisnikPrezime = "Prezime1",
            Uloga = "Korisnik"
        };
        Korisnik korisnik2 = new()
        {
            KorisnikId = 2,
            KorisnikIme = "Korisnik2",
            KorisnikPrezime = "Prezime2",
            Uloga = "Admin"
        };
        Korisnik korisnik3 = new()
        {
            KorisnikId = 3,
            KorisnikIme = "Korisnik3",
            KorisnikPrezime = "Prezime3",
            Uloga = "Korisnik"
        };

        Lokacija lokacija1 = new()
        {
            LokacijaId = 1,
            LokacijaNaziv = "Nis",
        };
        Lokacija lokacija2 = new()
        {
            LokacijaId = 2,
            LokacijaNaziv = "Beograd"
        };
        Lokacija lokacija3 = new()
        {
            LokacijaId = 3,
            LokacijaNaziv = "Novi Sad"
        };

        TipPostupka tipPostupka1 = new()
        {
            TipPostupkaId = 1,
            TipPostupkaNaziv = "TipPostupka 1"
        };
        TipPostupka tipPostupka2 = new()
        {
            TipPostupkaId = 2,
            TipPostupkaNaziv = "Tip postupka 2"
        };

        Parnica parnica = new()
        {
            ParnicaId = 1,
            DatumVremeOdrzavanja = new DateTime(2023, 12, 22),
            TipUstanove = "Tip1",
            IdentifikatorPostupka = "Identifikator1",
            BrojSudnice = 1,
            Napomena = "Napomena1",
        };
        Parnica parnica2 = new()
        {
            ParnicaId = 2,
            DatumVremeOdrzavanja = new DateTime(2023, 06, 22),
            TipUstanove = "Tip2",
            IdentifikatorPostupka = "Identifikator2",
            BrojSudnice = 2,
            Napomena = "Napomena2",
        };
        Parnica parnica3 = new()
        {
            ParnicaId = 3,
            DatumVremeOdrzavanja = new DateTime(2023, 07, 22),
            TipUstanove = "Tip3",
            IdentifikatorPostupka = "Identifikator3",
            BrojSudnice = 3,
            Napomena = "Napomena3",
        };

        modelBuilder.Entity<Kompanija>()
            .HasData(kompanija1, kompanija2, kompanija3);

        modelBuilder.Entity<Kontakt>()
            .HasData(kontakt1, kontakt2, kontakt3);

        modelBuilder.Entity<Korisnik>()
            .HasData(korisnik1, korisnik2, korisnik3);

        modelBuilder.Entity<Lokacija>()
            .HasData(lokacija1, lokacija2, lokacija3);

        modelBuilder.Entity<TipPostupka>()
            .HasData(tipPostupka1, tipPostupka2);

        modelBuilder.Entity<Parnica>()
            .HasData(parnica, parnica2, parnica3);

        /*modelBuilder.Entity<Parnica>()
            .HasOne(l => l.ParnicaLokacija)
            .WithOne(p => p.Parnica)
            .HasForeignKey<Lokacija>(l => l.ParnicaID);*/

        /*modelBuilder.Entity<Kontakt>()
            .HasOne(k => k.PripadnostKompaniji)
            .WithMany(k => k.Kontakti)
            .HasForeignKey(k => k.PripadnostKompanijiId);

        modelBuilder.Entity<Parnica>()
            .HasOne(k => k.Sudija)
            .WithMany(p => p.Parnice)
            .HasForeignKey(k => k.SudijaId);
        
        modelBuilder.Entity<Parnica>()
            .HasOne(t => t.Tuzenik)
            .WithMany(p => p.Parnice)
            .HasForeignKey(t => t.TuzenikId);
        
        modelBuilder.Entity<Parnica>()
            .HasOne(t => t.Tuzilac)
            .WithMany(p => p.Parnice)
            .HasForeignKey(t => t.TuzilacId);

        modelBuilder.Entity<Parnica>()
            .HasOne(tp = tp.TipPostupka)
            .WithMany(p => p.Parnice)
            .HasForeignKey(tp => tp.TipPostupkaId);*/

        modelBuilder.Entity<Parnica>()
            .HasMany(a => a.ZaduzeniAdvokati)
            .WithMany(p => p.Parnice)
            .UsingEntity(e => e.HasData(
                // Parnici 1 dodeljeni su svi advokati
                new { ParniceParnicaId = 1, ZaduzeniAdvokatiKorisnikId = 1 },
                new { ParniceParnicaId = 1, ZaduzeniAdvokatiKorisnikId = 2 },
                new { ParniceParnicaId = 1, ZaduzeniAdvokatiKorisnikId = 3},

                //Parnici 2 dodeljen je advokat 1
                new { ParniceParnicaId = 2, ZaduzeniAdvokatiKorisnikId = 1},

                //Parnici 3 dodeljen je advokat 2
                new { ParniceParnicaId = 3, ZaduzeniAdvokatiKorisnikId = 2}
            ));
    }
}