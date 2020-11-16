using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace laba_13_File_System
{
     class SKIDiskInfo
    {
        
        public static void DiskInfo()
        {
            foreach(var drive in DriveInfo.GetDrives()) {
                Console.WriteLine("____________________________________________________________________");
                Console.WriteLine("Имя диска - " + drive.Name);
                Console.WriteLine("Файловая система - " + drive.DriveFormat);
                Console.WriteLine("Свободное место на диске - " + (float)drive.TotalFreeSpace/1000000000 + " GB");
                Console.WriteLine("Общее место на диске - " + (float)drive.AvailableFreeSpace/1000000000+ " GB");
                Console.WriteLine("Метка тома - " + drive.VolumeLabel);
                Console.WriteLine("Объем памяти - " + (float)drive.TotalSize/1000000000+ " GB");
                
            
            }
            SKILog.WriteInFile("Была выведена информация о диске в консоль");
        }
    }
}
