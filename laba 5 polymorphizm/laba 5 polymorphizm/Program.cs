
using System;
using System.Reflection;

namespace laba_5_polymorphizm
{
    class Program
    {


        class Printer
        {


            public virtual void IAmPrinting(Transport obj)
            {
                obj.ToString();
            }



        }
        interface IPrintable
        {
            void Print();
           
        }
        interface IPrintableAnother
        {
            void Print();

        }
        public abstract class Transport
        {
           
            public virtual void ToString()
            {
                Console.WriteLine($"Id транспорта - {Id}");
            }
            public abstract int Id { get; set; }

        }
        public abstract class Aviation:Transport
        {
            private int weight;
            public override void ToString()
            {
                Console.WriteLine($"Вес самолета - {Weight}");
            }
            public abstract int Weight
            {
                get; set;
            }

            public class Cargo : Aviation
            {
                public Cargo(int Id , int Weight)
                {
                    this.Weight = Weight;
                    this.Id = Id;
                }
                public override int  Id { get; set; }
                private int weight;
                public override void ToString()
                {
                    Console.WriteLine($"Вес грузового самолета - {Weight}  , его Id  - {Id}");
                }
                public override int Weight
                {
                    get
                    {
                        return weight;
                    }
                    set
                    {
                        weight = value;
                    }
                }
            }
            public class Military : Aviation
            {
                public Military(int Id, int Weight)
                {
                    this.Weight = Weight;
                    this.Id = Id;
                }
                public override void ToString()
                {
                    Console.WriteLine($"Вес военного самолета - {Weight}  , его Id  - {Id}");
                }
                public override int Id { get; set; }
                private int weight;
                public override int Weight
                {
                    get
                    {
                        return weight;
                    }
                    set
                    {
                        weight = value;
                    }
                }
                
            }
            public class Passenger : Aviation
            {
                public Passenger(int Id, int Weight)
                {
                    this.Weight = Weight;
                    this.Id = Id;
                }
                public override void ToString()
                {
                    Console.WriteLine($"Вес пассажирского  самолета - {Weight}  , его Id  - {Id}");
                }
                public override int Id { get; set; }
                private int weight;
                public override int Weight
                {
                    get
                    {
                        return weight;
                    }
                    set
                    {
                        weight = value;
                    }
                }
               
            }
            public sealed class Tu134 : Military, IPrintable, IPrintableAnother
            {
                public string Weapon { get; set; }
                private int weight;
                public override int Id { get; set; }
                public override int Weight
                {
                    get
                    {
                        return weight;
                    }
                    set
                    {
                        weight = value;
                    }
                }
                public Tu134(int Id, int Weight, string Weapon) : base(Id, Weight)
                {
                    this.Weapon = Weapon;
                    this.Weight = Weight;
                    this.Id = Id;
                }
                public override void ToString()
                {
                    Console.WriteLine($"Вес самолета ТУ134 - {Weight}  , его Id  - {Id} , оружие - {Weapon}");
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
                public string Pilot { get; set; }
                public Boeing(int Id, int Weight, string Pilot) : base(Id, Weight)
                {
                    this.Pilot = Pilot;
                    this.Weight = Weight;
                    this.Id = Id;
                }
                public override void ToString()
                {
                    Console.WriteLine($"Вес самолета Boeing - {Weight}  , его Id  - {Id} , пилот -{Pilot}");
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
        static void Main(string[] args)
        {
            
            Aviation.Cargo cargo = new Aviation.Cargo(1,16);
            Aviation.Military military = new Aviation.Military(2, 6);
            Aviation.Passenger passenger = new Aviation.Passenger(3, 10);
            Aviation.Military.Tu134 tu134 = new Aviation.Military.Tu134(132,556,"Pulemets");
            Aviation.Boeing boeing = new Aviation.Boeing(100,1000,"John");
            IPrintable printable = tu134 as IPrintable;
            if (printable != null)
                Console.WriteLine("Поддержка IPrintable");
            else
                Console.WriteLine("IPrintable не поддерживается");
            if (tu134 is IPrintable)
                Console.WriteLine("Реализован");
            else
                Console.WriteLine("Не реализован");
            Printer printer = new Printer();
            Aviation[] aviations = new Aviation[5] {cargo,military,passenger,tu134,boeing} ;
           for(int i = 0; i < 5; i++)
            {
                printer.IAmPrinting(aviations[i]);

            }
           
            ((IPrintableAnother)tu134).Print();
            ((IPrintableAnother)boeing).Print();
            ((IPrintable)tu134).Print();
        }
    }
}
