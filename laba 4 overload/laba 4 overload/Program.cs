using System;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace laba_4_overload
{

    public static class StringOperation
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }

    class Program
    {
        public static class StatisticOperation
        {

            public static int FirstNum(Matrix matrix, int column)
            {
                int[,] mas = matrix.Mas; int number;
                number = mas[column, 0];
                return number;

            }
            public static void Negative(Matrix matrix)
            {
                int[,] mas = matrix.Mas;
                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;


                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (mas[i, j] < 0)
                            mas[i, j] = 0;
                    }

                }
                matrix.Mas = mas;
                Console.WriteLine();
            }
        }


        public class Matrix
        {
            private int[,] mas;// поле
            public int[,] Mas {
                get
                {
                    return mas;
                }
                set
                {
                    mas = value;
                }


            }
            public Matrix(int[,] mas)
            {
                this.mas = mas;
            }
            public Matrix(int x, int y)
            {
                int[,] mas = new int[x, y];

                Random random = new Random();
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        mas[i, j] = random.Next(100);

                    }

                }
                Mas = mas;
            }
            public void print()
            {
                int rows = Mas.GetUpperBound(0) + 1;
                int columns = Mas.Length / rows;


                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        Console.Write($"{Mas[i, j]} \t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }


            public class Owner
            {
                public string Name { get; set; }
                public string Organization { get; set; }
                public int Id { get; set; }

                public Owner(int id, string org, string name)
                {
                    Id = id;
                    Name = name;
                    Organization = org;
                }
            }

            Owner ownerOne = new Owner(199, "БГТУ", "Костя");

            public class Date
            {
                public string Mes { get; set; }
                public string Day { get; set; }
                public int Hours { get; set; }
                public int Min { get; set; }
                public int Sec { get; set; }

                public Date(int hours, int min, int sec, string day, string mes)
                {
                    Hours = hours;
                    Min = min;
                    Sec = sec;
                    Day = day;
                    Mes = mes;
                }
            }

            Date today = new Date(12, 44, 56, "Monday", "September");
            // перегрузка
            public static Matrix operator --(Matrix matrix)
            {
                int[,] mas;
                mas = matrix.Mas;

                int rows = mas.GetUpperBound(0) + 1;
                int columns = mas.Length / rows;


                for (int i = 0; i < rows; i++)
                {

                    for (int j = 0; j < columns; j++)
                    {
                        mas[i, j] = 0;

                    }

                }
                matrix.Mas = mas;
                return matrix;
            }

            public static int[,] operator +(Matrix matrix1, Matrix matrix2)
            {
                int[,] mas1, mas2, SumMas;
                SumMas = matrix1.Mas;
                mas1 = matrix1.Mas;
                mas2 = matrix2.Mas;

                int rows = mas1.GetUpperBound(0) + 1;
                int columns = mas1.Length / rows;
                int rows2 = mas2.GetUpperBound(0) + 1;
                int columns2 = mas2.Length / rows;
                if (rows == rows2 && columns == columns2)
                {
                    for (int i = 0; i < rows; i++)
                    {

                        for (int j = 0; j < columns; j++)
                        {
                            SumMas[i, j] = mas1[i, j] + mas2[i, j];

                        }

                    }

                    return SumMas;
                }
                else
                {

                    Console.WriteLine("Размерности матриц не совпадают\n");
                    int[,] nullMas = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
                    return nullMas;

                }

            }
            public static bool operator ==(Matrix matrix1, Matrix matrix2)
            {
                int[,] mas1, mas2;

                mas1 = matrix1.Mas;
                mas2 = matrix2.Mas;

                int rows = mas1.GetUpperBound(0) + 1;

                int rows2 = mas2.GetUpperBound(0) + 1;

                if (rows == rows2)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        if (mas1[i, 0] != mas2[i, 0])
                            return false;
                    }
                    return true;


                }
                else
                {

                    Console.WriteLine("Размерности матриц не совпадают\n");
                    return false;

                }

            }
            public static bool operator !=(Matrix matrix1, Matrix matrix2)
            {
                int[,] mas1, mas2;

                mas1 = matrix1.Mas;
                mas2 = matrix2.Mas;

                int rows = mas1.GetUpperBound(0) + 1;

                int rows2 = mas2.GetUpperBound(0) + 1;

                if (rows == rows2)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        if (mas1[i, 0] != mas2[i, 0])
                            return true;
                    }
                    return false;


                }
                else
                {

                    Console.WriteLine("Размерности матриц не совпадают\n");
                    return true;

                }

            }
            public static explicit operator int(Matrix matrix1)
            {
                int[,] mas1;
                mas1 = matrix1.Mas;

                byte counterNeg = 0;
                int rows = mas1.GetUpperBound(0) + 1;
                int columns = mas1.Length / rows;


                for (int i = 0; i < rows; i++)
                {

                    for (int j = 0; j < columns; j++)
                    {
                        if (mas1[i, j] < 0)
                            counterNeg++; ;

                    }

                }
                return counterNeg;


            }
        }



        static void Main(string[] args)
        {
            int[,] nums1 = new int[,] { { 0, -1, 2 }, { 3, -4, -5 }, { 0, 1, -2 } };
            int[,] nums2 = new[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 3, 4, 5 } };
            int[,] nums3 = { { 0, 1, 2 }, { 3, 4, 5 } };
            Matrix matrixOne = new Matrix(nums1);
            Matrix matrixTwo = new Matrix(5, 5);
            Matrix matrixThree = new Matrix(nums2);
            Matrix matrixFour = new Matrix(nums1);
            int countNeg = (int)matrixOne;
            Console.WriteLine($"Количество отрицательных элементов -  { countNeg}");
            matrixOne.print();
            StatisticOperation.Negative(matrixOne);
            Console.WriteLine(StatisticOperation.FirstNum(matrixTwo, 2));
            matrixOne.print();
            matrixTwo.print();
            matrixThree.print();
            Matrix matrixSum = new Matrix(matrixOne + matrixThree);
            matrixSum.print();
            string Nword = "ппппприветик";
            Console.WriteLine(StringOperation.CharCount(Nword, 'п'));
            Console.WriteLine(matrixOne == matrixFour);
            Matrix.Owner owner = new Matrix.Owner(12, "dfs", "dsff");
            matrixOne--;
            matrixOne.print();


        }
    }
}
