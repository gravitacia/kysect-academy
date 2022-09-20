using KysectAcademyTask.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace KysectAcademyTask.DataBases;

public class SubmissionInfo : DbContext
{
    public DbSet<Submission> SubmisssionInfos { get; set; }
    
    public SubmissionInfo()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
    }
}