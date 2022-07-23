using KysectAcademyTask.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DataBases;

public class ApplicationContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }
}