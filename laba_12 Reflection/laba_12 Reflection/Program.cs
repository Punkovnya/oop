using System;
using System.Reflection;
using System.IO;

namespace laba_12_Reflection
{

    public class Matrix
    {
        private int[,] mas;// поле
        public int[,] Mas
        {
            get
            {
                return mas;
            }
            set
            {
                mas = value;
            }


        }
        public Matrix(int[,] mas)
        {
            this.mas = mas;
        }
        public Matrix()
        {
            
        }
        public Matrix(int x, int y)
        {
            int[,] mas = new int[x, y];

            Random random = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    mas[i, j] = random.Next(100);

                }

            }
            Mas = mas;
        }
        public void print()
        {
            int rows = Mas.GetUpperBound(0) + 1;
            int columns = Mas.Length / rows;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{Mas[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void printTo(string str)
        {
            Console.WriteLine(str);
        }

    }








        class Concert : IComparable<Concert>
    {
        public int CompareTo(Concert concert)
        {
            if (this.Cost > concert.Cost)
                return 1;
            else if (this.Cost < concert.Cost)
                return -1;
            else return 0;
        }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public Concert(string Name, int Cost, int Month, int Year)
        {
            this.Name = Name;
            this.Cost = Cost;
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }
        public void Print()
        {
            Console.WriteLine($"Концерт {Name}, стоимость {Cost}, дата {Day}.{Month}.{Year}");
        }


    }
    public static class Reflector
    {
        public static void InFile(string str)
        {
            string path = @"C:\data\info.txt";
          
            File.AppendAllText(path, str);
            // запись в файл
           /* DirectoryInfo dirInfo = new DirectoryInfo(path);
            using (StreamWriter streamWrite = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                
                streamWrite.WriteLine(str);
                
            }
            */
        }

        public static void Name<T>(T obj)
        {
            Assembly a = typeof(T).Assembly;
            InFile(a.FullName+"\n");
            Console.WriteLine(a.FullName);
        }
        public static void Construct<T>(T obj)
        {
            ConstructorInfo[] constructorInfo = typeof(T).GetConstructors();
            foreach (ConstructorInfo ctor in constructorInfo)
            {
                ParameterInfo[] parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    InFile(parameters[i].ParameterType.Name + " " + parameters[i].Name+"\n");
                    if (i + 1 < parameters.Length) { Console.Write(", "); InFile(", "); }
                }
               
            }
        }
            public static void IsPublic<T>(T obj)
            {
                ConstructorInfo[] constructorInfo = typeof(T).GetConstructors();
            for (int i = 0; i < constructorInfo.Length; i++)
                if ((constructorInfo[i].IsPublic))
                {
                    Console.WriteLine("\nКласс Concert имеет публичный конструктор");
                    InFile("\nКласс Concert имеет публичный конструктор");
                }
                else
                {
                    Console.WriteLine("\nКласс Concert не имеет публичный конструктор");
                    InFile("\nКласс Concert не имеет публичный конструктор");
                }
            }
        public static void AllMethods<T>(T obj)
        {

            Type myType = Type.GetType("laba_12_Reflection.Concert", false, true);
            MethodInfo[] methodInfo = typeof(T).GetMethods();
            foreach (MethodInfo method in methodInfo)
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} ");
                InFile($"{modificator} {method.ReturnType.Name} {method.Name} ");
            }
        }
       
        public static void AllFields<T>(T obj)
        {

            
            FieldInfo[] fieldInfo = typeof(T).GetFields();
            
            foreach (FieldInfo field in fieldInfo)
            {
                
                string modificator = "";
                if (field.IsStatic)
                    modificator += "Static";
                if (field.IsPrivate)
                    modificator += "Private";
                Console.Write($"{modificator} {field.FieldType.Name} {field.Name} ");
                InFile($"{modificator} {field.FieldType.Name} {field.Name} ");
                
            }
            InFile("\n");
            Console.WriteLine();
        }
        public static void AllInterface<T>(T obj)
        {


            Type[] interfaceInfo = typeof(T).GetInterfaces();
            for(int i = 0; i < interfaceInfo.Length; i++)
            {
                Console.WriteLine($"Реализованные интерфейсы -  {interfaceInfo[i].Name}");
                InFile($"Реализованные интерфейсы -  {interfaceInfo[i].Name}");
            }
            InFile("\n");
            Console.WriteLine();
        }

        public static void FindMethods<T>(T obj,string type)
        {

            Type myType = Type.GetType("laba_12 Reflection.Concert", false, true);
            MethodInfo[] methodInfo = typeof(T).GetMethods();
            Console.Write("Методы с типом " + type + " : ");
            foreach (MethodInfo method in methodInfo)
            {
                string modificator = "";
                if (method.IsStatic)
                    modificator += "static ";
                if (method.IsVirtual)
                    modificator += "virtual";
                if(Convert.ToString(method.ReturnType) == type)
                
                Console.Write($"{modificator} {method.Name} ");
                InFile($"{modificator} {method.Name} ");
            }
        }
        public static void Invoke<S>(string methodName,string className,S parametrs)
        {

            Assembly asm = Assembly.LoadFrom("laba_12 Reflection.dll");

            Type t = asm.GetType("laba_12_Reflection." + className, true, true);

           
            object obj = Activator.CreateInstance(t);

      
            MethodInfo method = t.GetMethod(methodName);

         
            object result = method.Invoke(obj, new object[] { parametrs});
            Console.WriteLine((result));
        }

        public static object Create(string className)
        {

            Assembly asm = Assembly.LoadFrom("laba_12 Reflection.dll");

            Type t = asm.GetType("laba_12_Reflection." + className, true, true);
            object obj = Activator.CreateInstance(t);


            return obj;
        }


    }
    class Program
    {


        static void Main()
        {
            Concert concert = new Concert("Retuses", 15, 9, 2020);
            Reflector.Name(concert);
            Reflector.Construct(concert);
            Reflector.IsPublic(concert);
            Reflector.AllMethods(concert);
            Reflector.AllFields(concert);
            Reflector.AllInterface(concert);
            Reflector.FindMethods(concert, "System.Int32");
            Reflector.Invoke("printTo","Matrix","Мой текст");
            Console.WriteLine(Reflector.Create("Matrix").ToString());
        }
    }

}
