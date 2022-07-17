namespace KysectAcademyTask;

public class ComparisonLogic
{
    public double CompareFilesByBites(string? firstFile, string? secondFile)
    {
        int count = 0;
        double percent = 0.0;

        if (firstFile != null)
        {
            using FileStream first = File.OpenRead(firstFile);
            if (secondFile != null)
            {
                using FileStream second = File.OpenRead(secondFile);
                for (int i = 0; i < first.Length; i++)
                {
                    if (first.ReadByte() != second.ReadByte())
                        count++;
                }

                string str1 = File.ReadAllText(firstFile);
                string str2 = File.ReadAllText(secondFile);

                if (str1.Length > str2.Length)
                {
                    percent = Convert.ToDouble(count) / Convert.ToDouble(str1.Length);

                }
                else
                {
                    percent = Convert.ToDouble(count) / Convert.ToDouble(str2.Length);
                }
            }
        }

        return percent;
    }


    public double CompareFolders(string firstPath, string secondPath)
    {
        var percentsForFile = new List<double>();
        var percents = new List<List<double>>();
        var tmpList = new List<double>();
        var tmpListForPercent = new List<List<double>>();
        double finalPercent = 0.0;
        var _configuration = new Configuration();

        if (firstPath == null) throw new Exception("Invalid path!");
        if (secondPath == null) throw new Exception("Invalid path!");

        var dir2 = new DirectoryInfo(secondPath);
        var dir1 = new DirectoryInfo(firstPath);

        IEnumerable<FileInfo> list1 = dir1.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> list2 = dir2.GetFiles("*.*", SearchOption.AllDirectories);


        foreach (FileInfo curFirstFile in list1)
        {
            foreach (FileInfo curSecondFile in list2)
            {
                double percent = CompareFilesByBites(curFirstFile.DirectoryName, curSecondFile.DirectoryName);
                percentsForFile.Add(percent);

                if (percent >= 0.3)
                {
                    tmpList.Add(percent);
                }
            }

            percents.Add(percentsForFile);
            tmpListForPercent.Add(tmpList);
        }

        finalPercent += tmpListForPercent.Sum(curPercent => curPercent.Sum());

        finalPercent = percents.Aggregate(finalPercent, (current, curPercent) => current / curPercent.Sum());

        return finalPercent;
    }

    public double CompareFolders(string path)
    {

        var percentsForFile = new List<double>();
        var percents = new List<List<double>>();
        var tmpList = new List<double>();
        var tmpListForPercent = new List<List<double>>();
        double finalPercent = 0.0;
        var dir = new DirectoryInfo(path);
        IEnumerable<FileInfo> list1 = dir.GetFiles("*.*", SearchOption.AllDirectories);
        IEnumerable<FileInfo> list2 = dir.GetFiles("*.*", SearchOption.AllDirectories);
        
        foreach (FileInfo curFirstFile in list1)
        {
            foreach (FileInfo curSecondFile in list2)
            {
                double percent = CompareFilesByBites(curFirstFile.DirectoryName, curSecondFile.DirectoryName);
                percentsForFile.Add(percent);

                if (percent != 1.0)
                {
                    tmpList.Add(percent);
                }
            }

            percents.Add(percentsForFile);
            tmpListForPercent.Add(tmpList);
        }

        
        finalPercent += tmpListForPercent.Sum(curPercent => curPercent.Sum());

        finalPercent = percents.Aggregate(finalPercent, (current, curPercent) => current / curPercent.Sum());

        return finalPercent;
    }
}

