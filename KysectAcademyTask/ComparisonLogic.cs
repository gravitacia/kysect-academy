namespace KysectAcademyTask;

public class ComparisonLogic : IAlgorithmLogic
{
    public double CompareFiles(FileStream firstFile, FileStream secondFile)
    {
        int count = 0;
        double percent = 0.0;
        
        if (firstFile is null) return percent; 
        if (secondFile is null) return percent;
        
        for (int i = 0; i < firstFile.Length; i++)
        {
            if (firstFile.ReadByte() != secondFile.ReadByte())
                count++;
        }

        if (firstFile.Length > secondFile.Length)
        {
            percent = Convert.ToDouble(count) / Convert.ToDouble(firstFile.Length);

        }
        else
        {
            percent = Convert.ToDouble(count) / Convert.ToDouble(secondFile.Length);
        }

        return percent;
    }
}