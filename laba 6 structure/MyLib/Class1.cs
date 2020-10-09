using System;

namespace MyLib
{
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

            public Cargo(int Km, int Weight , int Fuel)
            {
                this.Weight = Weight;
                this.Km= Km;
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
            public  int Seats { get; set; }
            public override int Weight { get; set; }
            public override int Fuel { get; set; }
            public override int Km { get; set; }

            public Passenger(int Km, int Weight, int Fuel,int Seats)
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
            
            public override int Weight { get; set; }
            public override int Fuel { get; set; }
            public override int Km { get; set; }

            public Tu134(int Km, int Weight, int Fuel):base(Km,Weight,Fuel)
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
            public int Seats { get; set; }
            public override int Weight { get; set; }
            public override int Fuel { get; set; }
            public override int Km { get; set; }

            public Boeing(int Km, int Weight, int Fuel, int Seats):base(Km,Weight, Fuel, Seats)
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
}
