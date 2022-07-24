using KysectAcademyTask.DataBases;
using KysectAcademyTask.DbEntities;

namespace KysectAcademyTask.Config;

public class DbConfig
{
    public void SaveStudents(Student student)
    {
        using var db = new StudentsInfo();
        db.Students.Add(student);
        db.SaveChanges();
    }
    
    public void SaveSubmissions(Submission submission)
    {
        using var db = new SubmissionInfo();
        db.SubmisssionInfos.Add(submission);
        db.SaveChanges();
    }

    public void SaveSubmissionsCompare(SubmissionCompare submissionCompare)
    {
        using var db = new SubmissionCompareInfo();
        db.SubmisssionCompares.Add(submissionCompare);
        db.SaveChanges();
    }

    public List<Student> GetStudents()
    {
        using var db = new StudentsInfo();
        return db.Students.ToList();
    }
    
    public List<SubmissionCompare> GetSubmissionCompare()
    {
        using var db = new SubmissionCompareInfo();
        return db.SubmisssionCompares.ToList();
    }
    
    public List<Submission> GetSubmission()
    {
        using var db = new SubmissionInfo();
        return db.SubmisssionInfos.ToList();
    }
}
