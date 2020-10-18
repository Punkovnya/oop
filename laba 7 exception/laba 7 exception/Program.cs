using System;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Text;

namespace laba_7_exception
{
    public static class Logger
    {
        public static void FileLog(string message)
        {
            File.AppendAllText("log.txt", message);
        }
        public static void ConsoleLog(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
    public class Printer
    {
        public virtual void IAmPrinting(Transport obj)
        {
            obj.ToString();
        }

    }

    public interface IPrintable
    {
        void Print();

    }
    public interface IPrintableAnother
    {
        void Print();

    }
    public abstract class Transport
    {

        public virtual void ToString() { }

        public abstract int Weight { get; set; }

    }
    public abstract class Aviation : Transport
    {


        public abstract int Fuel { get; set; }
        public abstract int Km { get; set; }

        public override void ToString() { }



        public class Cargo : Aviation
        {
            public override void ToString()
            {
                Console.WriteLine($"грузоподъемность грузового транспорта - {Weight},объем топливного отсека - {Fuel} , дальность полета - {Km}");
            }
            public override int Weight { get; set; }
            public override int Fuel { get; set; }
            public override int Km { get; set; }

            public Cargo(int Km, int Weight, int Fuel)
            {
                this.Weight = Weight;
                this.Km = Km;
                this.Fuel = Fuel;
            }





        }
        public class Military : Aviation
        {
            public override void ToString()
            {
                Console.WriteLine($"грузоподъемность военного транспорта - {Weight},объем топливного отсека - {Fuel} , дальность полета - {Km}");
            }
            public override int Weight { get; set; }
            public override int Fuel { get; set; }
            public override int Km { get; set; }
            public Military()
            {
                throw new Nothing("Нельзя создать самолет без параметров");
            }
            public Military(int Km, int Weight, int Fuel)
            {
                this.Weight = Weight;
                this.Km = Km;
                this.Fuel = Fuel;
            }

        }
        public class Passenger : Aviation
        {
            public override void ToString()
            {
                Console.WriteLine($"грузоподъемность пассажирского транспорта - {Weight},объем топливного отсека - {Fuel} , дальность полета - {Km}, количество мест - {Seats}");
            }
            public int Seats { get; set; }
            public override int Weight { get; set; }
            public override int Fuel { get; set; }
            public override int Km { get; set; }

            public Passenger(int Km, int Weight, int Fuel, int Seats)
            {
                this.Weight = Weight;
                this.Km = Km;
                this.Fuel = Fuel;
                this.Seats = Seats;
            }

        }
        public sealed class Tu134 : Military, IPrintable, IPrintableAnother
        {

            public override void ToString()
            {
                Console.WriteLine($"грузоподъемность военного транспорта - {Weight},объем топливного отсека - {Fuel} , дальность полета - {Km}");
            }
            private int km;
            public int weight=3000 ;
            public override int Fuel { get; set; }
            public override int Km
            {
                get { return km; }
                set
                {
                    if (km < 0)
                        throw new NotNullException("Дальность не может быть меньше нуля", 211);

                    else
                        km = value;
                }
                
            }
            public override int Weight 
            {
                get { return weight; }
                set
                {
                    if (weight < 2000)
                        throw new WeightException("Вес не может быть меньше допустимого значения", 2000);
                    else
                        weight = value;
                }

            }


            public Tu134(int Km, int Weight, int Fuel) : base(Km, Weight, Fuel)
            {
                this.Weight = Weight;
                this.Km = Km;
                this.Fuel = Fuel;

            }

            void IPrintable.Print()
            {
                Console.WriteLine("Это военный самолет ТУ - 134 модификация 2001 года");
            }
            void IPrintableAnother.Print()
            {
                Console.WriteLine("Это военный самолет ТУ - 134 модификация 2009 года");
            }
        }
        public sealed class Boeing : Passenger, IPrintable, IPrintableAnother
        {
            public override void ToString()
            {
                Console.WriteLine($"грузоподъемность пассажирского транспорта - {Weight},объем топливного отсека - {Fuel} , дальность полета - {Km}, количество мест - {Seats}");
            }
            new public int Seats { get; set; }
            public override int Weight { get; set; }
            public override int Fuel { get; set; }
            public override int Km { get; set; }

            public Boeing(int Km, int Weight, int Fuel, int Seats) : base(Km, Weight, Fuel, Seats)
            {
                this.Weight = Weight;
                this.Km = Km;
                this.Fuel = Fuel;
                this.Seats = Seats;
            }
            void IPrintable.Print()
            {
                Console.WriteLine("Это пассажирский самолет Боинг модификации 2020 года ");
            }
            void IPrintableAnother.Print()
            {
                Console.WriteLine("Это пассажирский самолет Боинг модификации 2010 года");
            }

        }
    }
    class NotNullException : Exception
    {
        public string message;
        public int num;
        public NotNullException(string message, int num) : base(message)
        {
            this.num = num;
            this.message = message;
        }
    }
    class  Nothing: Exception
    {
        public string message;
        public Nothing(string message) : base(message)
        {
            this.message = message;
        }
    }
    class WeightException : Exception
    {
        public string message;
        public int MinWeight;
        public WeightException(string message,int MinWeight) : base(message)
        {
            this.message = message;
            this.MinWeight = MinWeight;
        }
    }



    class Program
    {

        static void Main(string[] args)
        {
            
            int x = 10, y = 0, z,Km,count;
            Console.WriteLine($"Введите дальность");
            Km =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите количество элементов массива для проверки от 1 до 4");
            count = Convert.ToInt32(Console.ReadLine());
            Aviation.Military.Tu134 tu134_1 = new Aviation.Tu134(900, 5000, 2000);
            Aviation.Military.Tu134 tu134_2 = new Aviation.Tu134(1000, 4000, 2000);
            Aviation.Military.Tu134 tu134_3 = new Aviation.Tu134(5000, 3000, 3000);
            Aviation.Military.Tu134 tu134_4 = new Aviation.Tu134(6000, 3000, 2000);
            Printer printer = new Printer();
            Aviation[] aviations = new Aviation[4] { tu134_1, tu134_2, tu134_3, tu134_4 };
            
            try
            {
                z = x / y;
            }
            catch (DivideByZeroException ex )
            {
                StringBuilder log = new StringBuilder();
                log.Append(DateTime.Now+"\n");
                log.Append(ex.StackTrace+"\n");
                log.Append("Ошибка: Деление на ноль" + "\n" +"________________________________________________" +"\n");
                Logger.FileLog(Convert.ToString(log));
                
            }

            try
            {
                Aviation.Military.Tu134 tu134 = new Aviation.Tu134(Km, 3000, 2000);
                tu134.ToString();
            }
            catch (NotNullException ex)
            {
                StringBuilder log = new StringBuilder();
                log.Append(DateTime.Now + "\n");
                log.Append(ex.StackTrace + "\n");
                log.Append("Ошибка:" + ex.Message + "\n" + "________________________________________________" + "\n");
                Logger.FileLog(Convert.ToString(log));
                
            }

            try
            {
                Aviation.Military military= new Aviation.Military();
            }
            catch (Nothing ex)
            {
                StringBuilder log = new StringBuilder();
                log.Append(DateTime.Now + "\n");
                log.Append(ex.StackTrace + "\n");
                log.Append("Ошибка:" + ex.Message + "\n" + "________________________________________________" + "\n");
                Logger.FileLog(Convert.ToString(log));
                
                
            }
           
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    printer.IAmPrinting(aviations[i]);

                }
            }
            catch(IndexOutOfRangeException ex)
            {
                StringBuilder log = new StringBuilder();
                log.Append(DateTime.Now + "\n");
                log.Append(ex.StackTrace + "\n");
                log.Append("Ошибка:" + ex.Message + "\n" + "________________________________________________" + "\n");
                Logger.FileLog(Convert.ToString(log));
            }

            try
            {
                Aviation.Military.Tu134 tu134_6 = new Aviation.Tu134(900, 1000, 2000);
                tu134_6.ToString();
            }
            catch (WeightException ex)
            {
                StringBuilder log = new StringBuilder();
                log.Append(DateTime.Now + "\n");
                log.Append(ex.StackTrace + "\n");
                log.Append("Ошибка:" + ex.Message + "\n" + "________________________________________________" + "\n");
                Logger.ConsoleLog(Convert.ToString(log));
            }
            finally
            {

            }
            static int Abs(int value)
            {
                if (value > 0)
                    return value;

                return -value;
            }
            Debug.Assert(Abs(-5) == 5);
            Debug.Assert(Abs(100) == 100);
        }
    }


}


