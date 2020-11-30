using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading;

namespace laba_15_Threads
{
    class INFO
    {
        static public void Info(Thread t)
        {
            Console.WriteLine($"Имя потока: {t.Name}");
            t.Name = "Метод Main";
            Console.WriteLine($"Имя потока: {t.Name}");

            Console.WriteLine($"Запущен ли поток: {t.IsAlive}");
            Console.WriteLine($"Приоритет потока: {t.Priority}");
            Console.WriteLine($"Статус потока: {t.ThreadState}");

            // получаем домен приложения
            Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");
        }
        static public void InfoAboutAllProc() {
            foreach (Process process in Process.GetProcesses())
            {
                // выводим id и имя процесса
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName} Priority: {process.BasePriority}  ");
            }
        }
        static public void infoDomen(AppDomain domain)
        {
            
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);
        }
}
}
