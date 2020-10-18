using System;
using System.Collections.Generic;
using System.Text;
using MyLib;

namespace laba_6_structure
{
    public partial class Controller
    {
        
        public int BoeingsSeats()
        {
            int SumSeats = 0;
            for (int i = 0; i < cargos.Count; i++)
            {
                SumSeats += cargos[i].Seats;

            }
            Console.WriteLine($"Oбщее количество мест - {SumSeats}");
            return SumSeats;
        }

        public int AllWeight()
        {
            int SumWeight = 0;
            for (int i = 0; i < militaries.Count; i++)
                SumWeight += militaries[i].Weight;


            for (int i = 0; i < cargos.Count; i++)
                SumWeight += cargos[i].Weight;

            Console.WriteLine($"Общая грузоподъемность - {SumWeight}");
            return SumWeight;
        }

        public void Find()
        {
            int diap1, diap2;
            Console.WriteLine($"Введите диапазон поиска");
            diap1 = Convert.ToInt32(Console.ReadLine());
            diap2 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < militaries.Count; i++)
            {
                if (militaries[i].Fuel <= diap2 && militaries[i].Fuel >= diap1)
                {
                    militaries[i].ToString();
                    ((IPrintable)militaries[i]).Print();
                }

                if (cargos[i].Fuel <= diap2 && cargos[i].Fuel >= diap1)
                {
                    cargos[i].ToString();
                    ((IPrintable)cargos[i]).Print();
                }

            }
        }

        public void SortMilitaries()
        {
            int temp;
            for (int i = 0; i < militaries.Count - 1; i++)
            {
                for (int j = i + 1; j < militaries.Count; j++)
                {
                    if (militaries[i].Km > militaries[j].Km)
                    {
                        temp = militaries[i].Km;
                        militaries[i].Km = militaries[j].Km;
                        militaries[j].Km = temp;
                    }
                }
            }

        }
        public void SortCargos()
        {
            int temp;
            for (int i = 0; i < cargos.Count - 1; i++)
            {
                for (int j = i + 1; j < cargos.Count; j++)
                {
                    if (cargos[i].Km > cargos[j].Km)
                    {
                        temp = cargos[i].Km;
                        cargos[i].Km = cargos[j].Km;
                        cargos[j].Km = temp;
                    }
                }
            }

        }
    }
}
