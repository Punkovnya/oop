using System;
using System.Reflection;

namespace laba_3_classes
{
    class Circle
    {
        private double radius;
        private int centerX,centerY;
        const double PI = 3.14;
        static int countOfObject=0;
        readonly int HashCode;
        public String hash = "circle";




        //private Circle(double RR, int CXX, int CYY) { 

        //    Radius = RR; CXX = CenterX; CYY = CenterY;

        //}
        public  static void ToString(Circle m)
        {
            Console.WriteLine($"Радиус-{m.Radius} Центр в координатах-({m.CenterX};{m.CenterY})");

        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Circle m = obj as Circle; // возвращает null если объект нельзя привести к типу Money
            if (m as Circle == null)
                return false;

            return m.centerX == this.CenterX && m.CenterY == this.CenterY;
        }
        public override int GetHashCode()
        {
            
            int unitCode;
            if (hash == "circle")
                unitCode = 1;
            else unitCode = 2;
            return (int)HashCode + unitCode;
        }
            public double Radius
            {
                get 
                {
                    return radius;
                }

                set
                {
                    radius=value;
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
                return centerX;
            }

            set
            {
                
            }

        }
        public Circle()
        {
            HashCode = 2;
            countOfObject++;
            Console.WriteLine("Создан круг");
            Console.WriteLine($"Количество уже созданных кругов: {countOfObject}");
        }
        static Circle()
        {
            
            Console.WriteLine("Создан круг");
        }

        public Circle(double R, int Cx, int Cy)
        {
            countOfObject++;
            HashCode = 2;
            radius = R;
            centerX = Cx;
            centerY = Cy;
            Console.WriteLine($"Количество уже созданных кругов: {countOfObject}");



        }
        public Circle(double R)
        {
            HashCode = 3;
            countOfObject++;
            radius = R;
            centerX = 0;
            centerY = 1;
            Console.WriteLine($"Количество уже созданных кругов: {countOfObject}");
        }

        public double length(ref double pi,double rad)
        {
            pi = PI;
            rad = radius;
            return (2 * pi * radius);

        }
        public double square(ref double pi,out double rad)
        {
            pi = PI;
            rad = radius;
            return (2 * pi * radius*radius);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            double Radius,PI=0;int CenterX, CenterY;
            Console.WriteLine("Radius:");
            Radius = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("CenterX:");
            CenterX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("CenterY");
            CenterY = Convert.ToInt32(Console.ReadLine());
            Circle circleOne = new Circle(Radius+3, CenterX, CenterY);
            Circle circleThree = new Circle(Radius+2, CenterX, CenterY);
            Circle circleTwo = new Circle();
            circleTwo.CenterX = 0;
            circleTwo.CenterY = 4;
            circleTwo.Radius = 2;
            Radius =circleTwo.Radius;
            Circle.ToString(circleOne);
            Console.WriteLine  (circleOne.Equals(circleTwo));
            Console.WriteLine  (circleOne.GetHashCode());
            Console.WriteLine(circleOne.length(ref PI,circleOne.Radius));
            Console.WriteLine(circleTwo.length(ref PI, circleTwo.Radius));
            Console.WriteLine(circleTwo.square(ref PI, out Radius));
            Circle[] newCircle = new Circle[3];
            newCircle[0] = circleOne;
            newCircle[1] = circleTwo;
            newCircle[2] = circleThree;
            for (int i = 0; i < newCircle.Length;i++)
            {
                for ( int j = 0 + i; j < newCircle.Length; j++)
                if(newCircle[i].CenterX == newCircle[j].CenterX)
                    {
                        Console.WriteLine($" Круг номер {i} с радиусом {newCircle[i].CenterX}= Круг номер{j} с радиусом {newCircle[j].CenterX}");
                    }
            }
            double maxSquare = 0;
            for (int i = 0; i < 3; i++)
            {
                if (newCircle[i].square(ref PI, out Radius) > maxSquare)
                    maxSquare = newCircle[i].square(ref PI, out Radius);
               
            }
            Console.WriteLine(maxSquare);
            var CircleNew = new { Radius = 23, X = 34,Y = 5 };
            Console.WriteLine(CircleNew.Radius);
        }
    }
}
