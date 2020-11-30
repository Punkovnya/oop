using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba_16_Parallel
{

    public class CustomMath
    {
        static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
        CancellationToken token = cancelTokenSource.Token;
        public uint n;
        public List<uint> numbers = new List<uint>();
        void AddToLIst()
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.Write("Заполнение");
            for (var i = 2u; i < n; i++)
            {
                if (i % 100 == 0) Console.Write(".");
                numbers.Add(i);
            }
        }
        void Sort()
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine();
            Console.Write("Сортировка");

            for (var i = 0; i < numbers.Count; i++)
            {
                if (i % 100 == 0) Console.Write(".");
                if (i == 100) cancelTokenSource.Cancel();
                for (var j = 2u; j < n; j++)
                {
                    if (token.IsCancellationRequested) { Console.WriteLine("Прервано"); return; }
                    numbers.Remove(numbers[i] * j);
                }
            }
        }



        public List<uint> SieveEratosthenesParallel()
        {

            Task task = new Task(AddToLIst);
            Task task2 = new Task(Sort);
            

            task.Start();
            task.Wait();
            
            task2.Start();
            task2.Wait();



            return numbers;
        }
        public List<uint> SieveEratosthenesConsistently()
        {
           
                Console.Write("Заполнение");
                
                for (var i = 2u; i < n; i++)
                {
                    if (i % 100 == 0) Console.Write(".");
                    numbers.Add(i);
                }
                Console.WriteLine();
                Console.Write("Сортировка");
                for (var i = 0; i < numbers.Count; i++)
                {
                    if (i % 100 == 0) Console.Write(".");
                    for (var j = 2u; j < n; j++)
                    {

                        numbers.Remove(numbers[i] * j);
                    }
                }
            return numbers;
        }



        public void Formula()
        {
            /*Func<int,int> func = Factorial;
            Task<int> task1 = new Task<int>(func.Invoke(6));*/
            Task<int> task1 = new Task<int>(() => Factorial(10));
            task1.Start();
            
            Task<int> task2 = task1.ContinueWith(y => Th(1));
           
            Task<int> task3 = task2.ContinueWith(x => octet(1000));
            
            Console.WriteLine(task1.Result + task2.Result - task3.Result);
        }
        static int Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }

            return result;
        }
        int Th(int x)
        {
            return x*1000;
        }
        int octet(int x)
        {
            return x * x * x * x;
        }

        static void Display(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
            Thread.Sleep(3000);
        }
        public int[] mas = new int[100000000];
        public int[] mas2 = new int[100000000];
        public void generateBigBooba()
        {
            Parallel.For(1, 100000000, BigBooba);
        }
        public void generateBigBoobaCons()
        {
            
           
            for (int i = 0; i < 100000000; i++)
                mas2[i] = i;
            
        }
        public void displayBigBoobaCons()
        {
            for (int i = 0; i < 100; i++)
                Console.WriteLine(mas2[i]);
        }
        public void displayBigBooba()
        {
            ParallelLoopResult result = Parallel.ForEach<int>(mas, BigBoobaa);
        }
        void BigBooba(int x)
        {
            mas[x] = x;
        }
        void BigBoobaa(int x)
        {
            Console.WriteLine(x);
        }
        static async void FactorialAsync()
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial(5));                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }
        void Manager(BlockingCollection<string> store, int time)
        {
            Thread.Sleep(time);
            store.Add("Item" + time);
        }


    }
}
