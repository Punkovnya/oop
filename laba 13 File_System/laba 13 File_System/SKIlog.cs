using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace laba_13_File_System
{
    public  static class SKILog
    {
        //конструктор FileStream
        public static void WriteInFile(string str)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("skilogfile.txt", true,System.Text.Encoding.Default)) 
                {
                    writer.WriteLineAsync( DateTime.Now + " - " + str);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " -ошибка записи в файл");
            }
            
        }

        public static string ReadOutFile(string str)
        {
            try
            {
                using (StreamReader reader= new StreamReader("skilogfile.txt"))
                {
                    str = reader.ReadToEnd();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " -ошибка чтения из файла");
            }
            return str;
        }
        public static void SearchWord(string word)
        {
            
            string x;
            StreamReader reader = new StreamReader("skilogfile.txt");
            while (reader.EndOfStream == false)
            {
                if ((x = reader.ReadLine()).Contains(word) == true)
                {
                    Console.WriteLine(x);
                }
            }

            reader.Close();
           
        }


    }
}
