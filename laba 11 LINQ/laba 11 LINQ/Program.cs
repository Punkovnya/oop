
using System;
using System.Collections.Generic;
using System.Linq;

namespace laba_11_LINQ
{

    class Circle 
    {

        private double radius;
        private int centerX, centerY;
        const double PI = 3.14;
        static int countOfObject = 0;
        public static void ToString(Circle m)
        {
            Console.WriteLine($"Радиус-{m.Radius} Центр в координатах-({m.CenterX};{m.CenterY})");

        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Circle m = obj as Circle;
            if (m as Circle == null)
                return false;

            return m.centerX == this.CenterX && m.CenterY == this.CenterY;
        }
        
        public double Radius
        {
            get
            {
                return radius;
            }

            set
            {
                radius = value;
            }

        }
        public int CenterX
        {
            get
            {
                return centerX;
            }

            set
            {
                centerX = value;
            }

        }
        public int CenterY
        {
            get
            {
                return centerY;
            }

            set
            {
                centerX = value;
            }

        }
       

        public Circle(double R, int Cx, int Cy)
        {
            countOfObject++;
      
            radius = R;
            centerX = Cx;
            centerY = Cy;
            Console.WriteLine($"Количество уже созданных кругов: {countOfObject}");



        }
       

        public double length(ref double pi, double rad)
        {
            pi = PI;
            rad = radius;
            return (2 * pi * radius);

        }
        public double square()
        {
           
            return (2 * PI * Radius * Radius);

        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            var LenghtN = Convert.ToInt32(Console.ReadLine());
            var MonthsWithNLength = from m in Months
                                    where m.Length == LenghtN
                                    orderby m
                                    select m;

            var SummerAndWinter = from m in Months
                                    where m.ToUpper().StartsWith("J") || m.ToUpper().StartsWith("F") || m.StartsWith("Au") || m.ToUpper().StartsWith("D")
                                  orderby m
                                    select m;

            var ContainsU = from m in Months
                                  where  m.Contains("u") && m.Length >= 4
                                  orderby m
                                  select m;


          

            foreach (string s in MonthsWithNLength)
                Console.WriteLine(s);

            Console.WriteLine();

            foreach (string s in SummerAndWinter)
                Console.WriteLine(s);

            Console.WriteLine();

            foreach (string s in ContainsU)
                Console.WriteLine(s);
            List<Circle> circles = new List<Circle>();
            

            circles.Add(new Circle(10, 5, 9));
            circles.Add(new Circle(10, 3, 7));
            circles.Add(new Circle(10, 5, 9));
            circles.Add(new Circle(9, 1, 3));
            circles.Add(new Circle(2, 5, 9));
            circles.Add(new Circle(5, 5, 10));
            circles.Add(new Circle(11, 1, 3));
            circles.Add(new Circle(2, 1, 4));


            Console.WriteLine(circles.Min(n => n.square())+"\n");
            Console.WriteLine(circles.Max(n => n.square()) + "\n");
            
            var circlesGroupX = from c in circles
                              group c by c.CenterX;
            Console.WriteLine("По прямой X"+"\n");
            
            foreach (IGrouping<int, Circle> c in circlesGroupX)
            {
                
                foreach (var t in c)
                    Console.WriteLine($"Радиус-{t.Radius} Центр в координатах-({t.CenterX} {t.CenterY})");
                Console.WriteLine();
            }

            var circlesGroupY = from c in circles
                               group c by c.CenterY;
            Console.WriteLine("По прямой Y"+"\n");
            foreach (IGrouping<int, Circle> c in circlesGroupY)
            {

                foreach (var t in c)
                    Console.WriteLine($"Радиус-{t.Radius} Центр в координатах-({t.CenterX} {t.CenterY})");
                Console.WriteLine();
            }


            int Rad = Convert.ToInt32(Console.ReadLine());

            var CircleRad = from c in circles
                            where c.Radius == Rad
                            group c by c.Radius;


            foreach (var c in CircleRad)
            {


                foreach (var t in c)
                    Console.WriteLine($"Радиус-{t.Radius} Центр в координатах-({t.CenterX} {t.CenterY})");
                Console.WriteLine();
            }



            var CircleRight = from c in circles 
                              where c.CenterX > 0 && c.CenterY > 0
                              select c;
            
                CircleRight.First().ToString();

            var CircleRadSort = from c in circles
                            orderby c.Radius
                            group c by c.Radius;


            foreach (var c in CircleRadSort)
            {


                foreach (var t in c)
                    Console.WriteLine($"Радиус-{t.Radius} Центр в координатах-({t.CenterX} {t.CenterY})");
                Console.WriteLine();
            }

        }
    }
}
