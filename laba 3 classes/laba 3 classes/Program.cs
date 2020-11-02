using System;
using System.Reflection;

namespace laba_3_classes
{
    
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
