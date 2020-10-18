using System;
using System.Collections.Generic;
using System.Text;
using MyLib;

namespace laba_6_structure
{
   public partial class Controller
    {
        public List<Aviation.Military.Tu134> militaries { get; set; }
        public List<Aviation.Cargo.Boeing> cargos { get; set; }
        public Controller(List<Aviation.Military.Tu134> militaries, List<Aviation.Cargo.Boeing> cargos)
        {
            this.cargos = cargos;
            this.militaries = militaries;
        }
        public void PrintMilitaries()
        {
            foreach (Aviation x in militaries) ((IPrintable)x).Print();
            foreach (Aviation x in militaries) x.ToString();
        }
        public void PrintBoeings()
        {
            foreach (Aviation x in cargos) ((IPrintable)x).Print();
            foreach (Aviation x in cargos) x.ToString();
        }
    }
}
