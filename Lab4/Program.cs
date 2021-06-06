using System;
using System.Collections.Generic;

namespace Backups
{
    class Program
    {
        static void Main(string[] args)
        {

            MainCleaner cl = new MainCleaner(0, new CountCleaner(1), new SizeCleaner(500));

            Backup bp = new Backup("backups/MyBackup", cl);
            bp.AddFullPoint("A", new List<string> { "files/A.txt", "files/B.txt" });
            bp.AddIncrementPoint("B", bp.GetPoint("A"), new List<string> { "files/A.txt", "files/B.txt" });
            bp.AddIncrementPoint("C", bp.GetPoint("B"), new List<string> { "files/A.txt", "files/B.txt" });
            List<string> st = bp.GetFiles();
            foreach (var i in st)
            {
                Console.WriteLine(i);
                Console.WriteLine(bp.GetFile(i).size);
            }

            

            Console.ReadKey();
        }
    }
}
