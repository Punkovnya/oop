using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace laba_13_File_System
{
    class SKIDirInfo
    {
        public static void DirInfo(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);


            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine("Имя каталога - " + dir.Name );
                Console.WriteLine("Время создания  - " + dir.CreationTime);
                
                Console.WriteLine("Список файлов в каталоге: ");
                foreach(FileInfo file in dir.GetFiles())
                {
                Console.WriteLine(file.Name);
                }
            Console.WriteLine("Список подкаталогов в каталоге: ");
            foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
            {
                Console.WriteLine(directoryInfo.Name);
            }
            Console.WriteLine($"Родительский каталог -  {dir.Parent} => {dir.Parent.Parent} => {dir.Parent.Parent.Parent}");
              


            
            SKILog.WriteInFile($"Была выведена информация о каталоге {dir.Name} в консоль");
        }

    }
}
