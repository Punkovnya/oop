using System;
using System.IO;
using System.Threading;

namespace laba_15_Threads
{
   
    class Program
    {
       
        static void Main(string[] args)
        {
            
            
            StreamReader fstream = new StreamReader(@"C:\Users\User\source\oop\laba 15 Threads\laba 15 Threads\bin\Debug\netcoreapp3.1\shop.txt");


            /* AppDomain domain = AppDomain.CurrentDomain;
             INFO.InfoAboutAllProc();
             Thread myThread = new Thread(new ParameterizedThreadStart(Methods.SimpleNum));
             Thread myThreadCht = new Thread(new ParameterizedThreadStart(Methods.ChtNum));
             Thread myThreadNcht = new Thread(new ParameterizedThreadStart(Methods.NchtNum));
             myThreadCht.Priority = ThreadPriority.Highest;
             Console.WriteLine(myThreadCht.Priority);
             //myThread.Start(100);
             TimerCallback callback = new TimerCallback(Methods.PrintTime);
             Timer timer = new Timer(callback, "USER", 100, 2000);
             myThreadCht.Start(20);
             myThreadNcht.Start(20);


             //myThread.Join()
             Thread.Sleep(100);

             INFO.Info(myThread);
             INFO.infoDomen(domain);*/
            //Methods.Domain();
            Thread machineThread1 = new Thread(new ParameterizedThreadStart(Methods.Machine1));
            Thread machineThread2 = new Thread(new ParameterizedThreadStart(Methods.Machine2));
            Thread machineThread3 = new Thread(new ParameterizedThreadStart(Methods.Machine3));
            machineThread1.Start(fstream);
            machineThread2.Start(fstream);
            machineThread3.Start(fstream);
        }
       
       
    }
}
