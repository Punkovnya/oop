using System;
using System.Reflection;
using MyLib;

namespace laba_6_structure
{

    

    
    
        class Program
        {


            
            static void Main(string[] args)
            {
            
                Aviation.Cargo cargo = new Aviation.Cargo(1, 16);
                Aviation.Military military = new Aviation.Military(2, 6);
                Aviation.Passenger passenger = new Aviation.Passenger(3, 10);
                Aviation.Military.Tu134 tu134 = new Aviation.Military.Tu134(132, 556, "Pulemets");
                Aviation.Boeing boeing = new Aviation.Boeing(100, 1000, "John");
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
                Aviation[] aviations = new Aviation[5] { cargo, military, passenger, tu134, boeing };
                for (int i = 0; i < 5; i++)
                {
                    printer.IAmPrinting(aviations[i]);

                }

                ((IPrintableAnother)tu134).Print();
                ((IPrintableAnother)boeing).Print();
                ((IPrintable)tu134).Print();
            }
        }
    

}
