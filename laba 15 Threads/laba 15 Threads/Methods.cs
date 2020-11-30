using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Reflection;

namespace laba_15_Threads
{
    
    class Methods
    {
        public static int i = 0;
        static Semaphore sem2 = new Semaphore(3,3);
        static Semaphore sem = new Semaphore(1, 2);
        public static void SimpleNum(object n)
        {
           

            
                Console.WriteLine("Главный поток:");
                for (int i = 2; i <= (int)n ; i++)
                {
                    bool b = true;
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0 & i % 1 == 0)
                        {
                            b = false;
                        }
                    }
                    if (b)
                    {
                        Console.WriteLine("{0} ", i);
                        File.AppendAllText("file.txt", i + " ");
                    }
                }
                
                
                Thread.Sleep(300);
            
        }
        public static void ChtNum(object n)
        {
            
            //sem.WaitOne();
            for ( ; i < (int)n; i++)
            {
               
                sem.WaitOne();
                Thread.Sleep(300);
                if (i % 2 == 0)
                {
                    
                    Console.WriteLine("Четныe числа - " + i);
                    sem.Release();
                }
                else
                sem.Release();
            }
            //sem.Release();
        }
        public static void NchtNum(object n)
        {
            //sem.WaitOne();
            for (; i < (int)n; i++)
            {
                
                sem.WaitOne();
                Thread.Sleep(300);
                if (i % 2 != 0)
                {
                    
                    Console.WriteLine("Нечетные числа - " + i);
                    sem.Release();
                }
                else
                    
                sem.Release();
                
            }
            //sem.Release();
        }
        public static void PrintTime(object name) 
        {
            Console.WriteLine((string)name +  " " + DateTime.Now);

        }
        public static void Domain()
        {
            
            AppDomain domain = AppDomain.CreateDomain("NewDomain");
            domain.Load(@"C:\Users\User\source\oop\laba 14 Serialization\laba 14 Serialization\bin\Debug\netcoreapp3.1\laba 14 Serialiation");
        }
        public static void Machine1(object obj)
        {


            StreamReader fs = (StreamReader)obj;

            
                for (int i = 0; i <= 3; i++)
                {
                
                    sem2.WaitOne();
                Thread.Sleep(100);
                Console.WriteLine("машина номер 1 разгрузила - " + fs.ReadLine());
                    sem2.Release();
                }
            


        }
        public static void Machine2(object obj)
        {

           
            StreamReader fs = (StreamReader)obj;
            
          
              
                for (int i = 0; i <= 3; i++)
                {
                
                sem2.WaitOne();
                Thread.Sleep(300);
                Console.WriteLine("машина номер 2 разгрузила - " + fs.ReadLine());
                    sem2.Release();
                }
            


        }
        public static void Machine3(object obj)
        {


            StreamReader fs = (StreamReader)obj;

            
                
                for (int i = 0; i <= 3; i++) {
                    sem2.WaitOne();
                Thread.Sleep(200);
                Console.WriteLine("машина номер 3 разгрузила - " + fs.ReadLine());
                    sem2.Release();
                }
                   
            


        }
    }
}
