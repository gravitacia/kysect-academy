using KysectAcademyTask.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DataBases;

public class SubmissionCompareInfo : DbContext
{
    public DbSet<SubmissionCompare> SubmisssionCompares { get; set; }
    
    public SubmissionCompareInfo()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }
}