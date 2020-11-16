using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace laba_13_File_System
{
    class SKIFileInfo
    {
        public static void DirInfo(string path)
        {
            FileInfo info = new FileInfo(path);
            Console.WriteLine("____________________________________________________________________");
            Console.WriteLine("Имя файла - " + info.Name);
            Console.WriteLine("Время создания  - " + info.CreationTime);
            Console.WriteLine("Время последнего доступа  - " + info.LastAccessTime);
            Console.WriteLine("Расширение - " + info.Extension);
            Console.WriteLine("Размер - " + info.Length);
            Console.WriteLine("Путь - " + path);




            SKILog.WriteInFile($"Была выведена информация о файле {info.Name} в консоль") ;
        }

    }
}
