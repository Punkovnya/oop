using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace laba_16_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            CustomMath customMath1 = new CustomMath();
            CustomMath customMath2 = new CustomMath();
            customMath1.n = 1000;
            customMath2.n = 1000;


            var sw1 = new Stopwatch();
            sw1.Start();
            var numbersConsistenly = customMath2.SieveEratosthenesConsistently();
            sw1.Stop();
            Console.WriteLine("\n Последовательные вычисления " + sw1.ElapsedMilliseconds + "\n");
            //foreach (uint n in numbersConsistenly) Console.WriteLine(n);
            //foreach (uint n in numbersParallel) Console.WriteLine(n);
            var sw2 = new Stopwatch();
            sw2.Start();
            var numbersParallel = customMath1.SieveEratosthenesParallel();
            sw2.Stop();
            Console.WriteLine("\nПараллельные вычисления " + sw2.ElapsedMilliseconds + "\n");


            customMath1.Formula();
            var sw3 = new Stopwatch();
           
            sw3.Start();
            customMath1.generateBigBooba();
            sw3.Stop();
            Console.WriteLine("\nПараллельная генерация массива  " + sw3.ElapsedTicks + "\n");
            var sw4 = new Stopwatch();
            sw4.Start();
            customMath1.generateBigBoobaCons();
            sw4.Stop();
            Console.WriteLine("\n Последовательная генерация массива  " + sw4.ElapsedTicks + "\n");

            //customMath1.displayBigBooba();
            customMath1.displayBigBoobaCons();
           /* uint storeLn = 0;
                Console.WriteLine();
            BlockingCollection<string> store = new BlockingCollection<string>();
            Parallel.Invoke(
                () =>
                {

                    while (true) {
                        Thread.Sleep(600);
                        Console.WriteLine(store.Take()+"-");
                        storeLn--;
                        
                    }
                        

                }, () =>
            {
                if (storeLn < 50)
                    while (true)
                    { 
                        Thread.Sleep(1000);
                    store.Add("Item1");


                        storeLn++;
                    Console.WriteLine("Item1+");
                    
                }
                  
            }, () =>
            {
                if (storeLn < 50)
                    while (true)
                    {
                        
                        Thread.Sleep(1100);
                    store.Add("Item2");
                        storeLn++;
                        Console.WriteLine("Item2+");
                }
            }, () =>
            {
                if (storeLn < 50)
                    while (true)
                    {
                        Thread.Sleep(900);
                    store.Add("Item3");
                        storeLn++;
                        Console.WriteLine("Item3+");
                }
            }, () =>
            {
                if (storeLn < 50)
                    while (true)
                    {
                        Thread.Sleep(800);
                    store.Add("Item4");
                        storeLn++;
                        Console.WriteLine("Item4+");
                }
            }, () =>
            {
                if(storeLn<50)
                while (true)
                {
                    Thread.Sleep(1000);
                    store.Add("Item5");
                        storeLn++;
                        Console.WriteLine("Item5+");
                }
            });
           */

        }
    }
}
