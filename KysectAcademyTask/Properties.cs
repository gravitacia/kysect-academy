﻿namespace KysectAcademyTask;

public class Properties
{
    public Properties(string path1, string path2, int percent)
    {
        Path1 = path1;
        Path2 = path2;
        Percent = percent;
    }

    public int Percent { get; set; }

    public string Path2 { get; set; }

    public string Path1 { get; set; }
}