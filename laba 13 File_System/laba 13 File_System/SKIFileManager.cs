using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace laba_13_File_System
{
    class SKIFileManager
    {
        public static void ReadDisk(string NameOfDisk)
        {
            string path;
            if (NameOfDisk == "D")
                path = "D:\\";
            else if (NameOfDisk == "C")
                path = "C:\\";
            else 
            throw new Exception("Такого диска не существует");
                
                
            DirectoryInfo dir = new DirectoryInfo(path);


            Console.WriteLine("____________________________________________________________________");
           

            Console.WriteLine("Список файлов в каталоге: ");
            foreach (FileInfo file in dir.GetFiles())
            {
                Console.WriteLine(file.Name);
            }
            Console.WriteLine("Список подкаталогов в каталоге: ");
            foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
            {
                Console.WriteLine(directoryInfo.Name);
            }



            SKILog.WriteInFile($"Был выведен список файлов и каталогов диска {NameOfDisk} в консоль");
        }

        public static void WriteInNewDirectory(string NameOfDisk,string pathDir, string newNameOfFile)
        {
            
            string subpath = "SKIInspect";
            string nameOfFile = "SKIDirInfo.txt";
            
            
            string path;
            if (NameOfDisk == "D")
                path = "D:\\";
            else if (NameOfDisk == "C")
                path = "C:\\";
            else
                throw new Exception("Такого диска не существует");


            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo Pathdir = new DirectoryInfo(pathDir);
            Pathdir.CreateSubdirectory(subpath);

            Console.WriteLine("____________________________________________________________________");
            
          
                try
                {
                   
                     
                      foreach (FileInfo file in dir.GetFiles())
                      {
                    File.WriteAllText(pathDir + "\\" + subpath + "\\" + nameOfFile, " - " + file.Name + "\n");
                      }
                   
                      foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
                      {
                    File.AppendAllText(pathDir + "\\" + subpath + "\\" + nameOfFile," - " + directoryInfo.Name + "\n");
                       }
                    
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + " -ошибка записи в файл");
                }
            
           File.Move(pathDir + "\\" + subpath + "\\" + nameOfFile, pathDir + "\\" + subpath + "\\" + newNameOfFile);
           
           



            SKILog.WriteInFile($"Был выведен список файлов и каталогов диска {NameOfDisk} в файл");
        }
        
            public static void AllExt(string Ext, string sourcePath , string destinPath , string destin1Path)
        {
            string path = @"D:\Darkest Dungeon";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("SKIFiles - " + Ext);
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine("Произведено перемещение");
            DirectoryInfo source = new DirectoryInfo(sourcePath);
            DirectoryInfo destin = new DirectoryInfo(destinPath);
            DirectoryInfo destin1 = new DirectoryInfo(destin1Path);
            foreach (FileInfo item in source.GetFiles().Where(x => x.Extension == Ext).ToList())
            {
                item.CopyTo(destin + item.Name, true); //копирование в новое место
            }
            if (!destin1.Exists)
            {
                
                destin.MoveTo(destin1.FullName); 
            }





            SKILog.WriteInFile($"Произведено перемещение каталога SKIFiles в SKIInspect");
        }

        public static void AllExt(string Ext, string sourcePath)
        {
            string path = sourcePath;
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("Файлы "+ Ext);
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine("Перемещение произведено");
            DirectoryInfo source = new DirectoryInfo(sourcePath);
            DirectoryInfo destin = new DirectoryInfo(sourcePath + "\\Файлы " + Ext + "\\");
            
            foreach (FileInfo item in source.GetFiles().Where(x => x.Extension == "."+Ext).ToList())
            {
                item.MoveTo(destin.FullName+item.Name);
            }
     
        }
        public static void Zip()
        {
           
            DirectoryInfo source = new DirectoryInfo(@"D:\Darkest Dungeon\SKIInspect\SKIFiles");

            ZipFile.CreateFromDirectory(source.FullName, source.FullName + ".zip");

            SKILog.WriteInFile($"Папка {source.FullName} архивирована в файл {source.FullName}.zip");
        }
        public static void UnZip( string FolderName)
        {

            DirectoryInfo source = new DirectoryInfo(@"D:\Darkest Dungeon\SKIInspect\SKIFiles");

            ZipFile.ExtractToDirectory(source.FullName + ".zip", FolderName);

            Console.WriteLine($"Файл {source.FullName + ".zip"} распакован в папку {FolderName}");
        }
       

    }
}
