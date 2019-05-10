/*
 把路径下所有文件夹中的MP4文件以文件夹名重命名
 */


using System;
using System.IO;

namespace RenameMP4
{
    class Program
    {
        static void Main(string[] args)
        {
            int cnt = 0;
            string rootPath = ".\\";

            DirectoryInfo rootDir = new DirectoryInfo(rootPath);
            DirectoryInfo[] subDirs = rootDir.GetDirectories("360*", SearchOption.TopDirectoryOnly);

            Console.WriteLine("Current directory: " + rootDir.FullName);

            foreach (DirectoryInfo dir in subDirs)
            {
                FileInfo[] files = dir.GetFiles("*.mp4", SearchOption.TopDirectoryOnly);

                if(files.Length<1)
                {
                    continue;
                }

                string oldName = files[0].Name;
                string newName = dir.FullName + "\\" + dir.Name + files[0].Extension;
                files[0].MoveTo(newName);

                Console.WriteLine(oldName + "\t-->\t" + files[0].Name);
                cnt++;
            }

            Console.WriteLine("{0} files renamed.", cnt);
            Console.ReadKey();
        }
    }
}
