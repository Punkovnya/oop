using System;
using System.Security.Cryptography.X509Certificates;

namespace laba_13_File_System
{
    
   public class Program
    {

        
        static void Main(string[] args)
        {



            SKIDiskInfo.DiskInfo();
            SKIDirInfo.DirInfo("C:\\Users\\User\\Downloads");
            SKIFileInfo.DirInfo("C:\\Users\\User\\Downloads\\KSIS.zip");
            SKIFileManager.ReadDisk("C");
            SKIFileManager.WriteInNewDirectory("D", "D:\\Darkest Dungeon", "NewFile.txt");
           
            SKIFileManager.Zip();
            SKIFileManager.UnZip("D:\\Darkest Dungeon");
            SKILog.SearchWord("Downloads");
           /* SKIFileManager.AllExt(args[0],@"C:\Users\User\Downloads");
              SKIFileManager.AllExt(args[1],@"C:\Users\User\Downloads");
              SKIFileManager.AllExt(args[2],@"C:\Users\User\Downloads");
              SKIFileManager.AllExt(args[3],@"C:\Users\User\Downloads");*/
            

        }
    }
}
