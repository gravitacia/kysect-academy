using KysectAcademyTask.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DataBases;

public class StudentsInfo : DbContext
{
    public DbSet<Student> Students { get; set; }
    
    public StudentsInfo()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }
}