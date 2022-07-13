using KysectAcademyTask;

string? rootPath = Deserializer.GetRootPath();
string? pathToSerialize = Deserializer.GetResultsPath();

new ComparisonLogic().GetResults(rootPath, pathToSerialize);

            string pathA = @"C:\Users\Alef Computers\Desktop\RootDirectory\M3236\Brandy May";  
            string pathB = @"C:\Users\Alef Computers\Desktop\RootDirectory\M3236\Eric Hayes";  
  
            var dir1 = new System.IO.DirectoryInfo(pathA);  
            var dir2 = new System.IO.DirectoryInfo(pathB);  
  
            // Take a snapshot of the file system.  
            IEnumerable<System.IO.FileInfo> list1 = dir1.GetFiles("*.*", System.IO.SearchOption.AllDirectories);  
            IEnumerable<System.IO.FileInfo> list2 = dir2.GetFiles("*.*", System.IO.SearchOption.AllDirectories);  
  
            //A custom file comparer defined below  
            var myFileCompare = new FileCompare();  
  
            // This query determines whether the two folders contain  
            // identical file lists, based on the custom file comparer  
            // that is defined in the FileCompare class.  
            // The query executes immediately because it returns a bool.  
            bool areIdentical = list1.SequenceEqual(list2, myFileCompare);  
  
            if (areIdentical == true)  
            {  
                Console.WriteLine("the two folders are the same");  
            }  
            else  
            {  
                Console.WriteLine("The two folders are not the same");  
            }  
  
            // Find the common files. It produces a sequence and doesn't
            // execute until the foreach statement.  
            IEnumerable<FileInfo> queryCommonFiles = list1.Intersect(list2, myFileCompare);  
  
            if (queryCommonFiles.Any())  
            {  
                Console.WriteLine("The following files are in both folders:");  
                foreach (FileInfo v in queryCommonFiles)  
                {  
                    Console.WriteLine(v.FullName); //shows which items end up in result list  
                }  
            }  
            else  
            {  
                Console.WriteLine("There are no common files in the two folders.");  
            }  
  
            // Find the set difference between the two folders.  
            // For this example we only check one way.  
            IEnumerable<FileInfo> queryList1Only = (from file in list1  
                                  select file).Except(list2, myFileCompare);  
  
            Console.WriteLine("The following files are in list1 but not list2:");  
            foreach (FileInfo v in queryList1Only)  
            {  
                Console.WriteLine(v.FullName);  
            }  
  
            // Keep the console window open in debug mode.  
            Console.WriteLine("Press any key to exit.");  
            Console.ReadKey();  
