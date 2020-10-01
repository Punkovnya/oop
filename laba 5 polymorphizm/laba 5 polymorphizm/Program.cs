
using System;

namespace laba_5_polymorphizm
{
    class Program
    { 
        public abstract class Transport
        {
            private int weight;
            public abstract int Weight
            {
                get;set;
            }
           

        }
        public class Aviation:Transport
        {
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
            public class Cargo
            {
               
            }
            public class Military
            {
                public class Tu134
                {

                }
            }
            public class Passenger
            {
                public class Boeing
                {

                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Aviation.Cargo cargo = new Aviation.Cargo();
            Aviation aviation = new Aviation();
            aviation.Weight = 10;
                
        }
    }
}
