
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10_Collections
{
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
        public Concert(string Name,int Cost,int Month,int Year)
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

    class Program
    {

        static void Main(string[] args)
        {
            bool flag = false;
            Concert retuses = new Concert("Retuses", 20, 03, 2020);
            Concert jamesblake = new Concert("James Blake", 70, 08, 2020);
            Concert shortparis = new Concert("Shortparis", 40, 07, 2020);
            Concert yunglean = new Concert("Yung Lean", 90, 04, 2020);
            Concert boniver = new Concert("Bon Iver", 70, 09, 2020);
            Dictionary<int, Concert> Concerts = new Dictionary<int, Concert>();
            Concerts.Add(20,retuses);
            Concerts.Add(21, jamesblake);
            Concerts.Add(3, shortparis);
            Concerts.Add(5, yunglean);
            Concerts.Add(10, boniver);
            foreach (int i in Concerts.Keys)
            {
                Concerts[i].Day = i;
                Concerts[i].Print();
            }
            Concerts.Remove(3);
            int key = Convert.ToInt32(Console.ReadLine());
            foreach (int i in Concerts.Keys)
            {
                
                if (i == key)
                {
                    flag = true;
                    Concerts[i].Print();
                }
            
            }
            if (flag == false)
                Console.WriteLine("В этот день концерта нет");

            Console.WriteLine("Введите начальную цифру диапазона");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите конечную цифру диапазона");
            int y = Convert.ToInt32(Console.ReadLine());
            int it = 0;
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "поппури");
            dictionary.Add(2, "фигуры");
            dictionary.Add(3, "глаз");
            dictionary.Add(4, "благодать");
            dictionary.Add(5, "капли");
            dictionary.Add(6, "каждый");
            dictionary.Add(7, "день");
            
            foreach (KeyValuePair<int, string> keyValue in dictionary)
            {

                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                
            }
            Console.WriteLine();
            foreach (int i in dictionary.Keys)
            {
                it++;
                if (it >= x && it <= y)
                    dictionary.Remove(i);
            }
            foreach (KeyValuePair<int, string> keyValue in dictionary)
            {
                
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
            List<string> vs = new List<string>();
            foreach (KeyValuePair<int, string> keyValue in dictionary)
            {

                vs.Add(keyValue.Value);
            }

            foreach (string Word in vs)
                Console.WriteLine(Word);

            Console.WriteLine();
            Console.WriteLine("Введите слово для поиска");
            string find =Console.ReadLine();
            foreach (string Word in vs)
                if(find == Word)
                Console.WriteLine(Word);

            ObservableCollection<Concert> p = new ObservableCollection<Concert>();
            void p_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Concert newConcert = e.NewItems[0] as Concert;
                        Console.WriteLine("Добавлен новый объект: " + newConcert.Name);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Concert oldIsland = e.OldItems[0] as Concert;
                        Console.WriteLine("Удален объект: " + oldIsland.Name);
                        break;
                }
            }

            p.CollectionChanged += p_CollectionChanged;

            p.Add(retuses);
            p.Add(jamesblake);
            p.Add(yunglean);
            p.RemoveAt(2);

            foreach (Concert i in p)
            {
                Console.WriteLine(i.ToString());
            }




        }
    }
}
