using System;
using System.Reflection;
using MyLib;
using System.Collections.Generic;

namespace laba_6_structure
{


    enum Methods : int { A,B,C,D,F,G};


    class Program
    {
        
       

            
            static void Main(string[] args)
            {
            Methods methods; methods = Methods.A;
            Console.WriteLine((int)methods);
            List<Aviation.Tu134> militaries = new List<Aviation.Tu134>();
            List<Aviation.Boeing> cargos = new List<Aviation.Boeing>();
            cargos.Add(new Aviation.Cargo.Boeing(1100, 1000, 3000, 140));
            militaries.Add(new Aviation.Military.Tu134(1900, 900, 1200));
            militaries.Add(new Aviation.Military.Tu134(1600, 1000, 1400));
            militaries.Add(new Aviation.Military.Tu134(2000, 800, 1000));
            militaries.Add(new Aviation.Military.Tu134(10000, 3000, 2000));
            cargos.Add(new Aviation.Cargo.Boeing(900, 1500, 3000, 100));
            cargos.Add(new Aviation.Cargo.Boeing(1200, 2000, 3000, 150));
            cargos.Add(new Aviation.Cargo.Boeing(1100, 1300, 3000, 90));
            BestPlane bestPlane = new BestPlane(cargos[0]);
            bestPlane.getBestPlane();
            Controller controller = new Controller(militaries,cargos);
            controller.AllWeight();
            controller.BoeingsSeats();
            controller.PrintBoeings();
            controller.PrintMilitaries();
            controller.SortCargos();
            controller.SortMilitaries();
            controller.Find();
        }
        }
    

}
