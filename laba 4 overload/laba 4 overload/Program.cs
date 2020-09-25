using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace laba_4_overload
{
    class Program
    {

        public class Matrix
        {
            private int[,] mas;// поле
            public int[,] Mas{
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
            public Matrix(int x,int y)
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

            public void Negative()
            {
                int rows = Mas.GetUpperBound(0) + 1;
                int columns = Mas.Length / rows;


                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (Mas[i, j] < 0)
                            Mas[i, j] = 0;
                    }
                   
                }
                Console.WriteLine();
            }


            // перегрузка
            public static Matrix operator --(Matrix matrix)
            {
                int [,]mas;
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
                matrix.Mas=mas;
                return matrix;
            }

            public static int [,] operator +(Matrix matrix1,Matrix matrix2)
            {
                int[,] mas1, mas2,SumMas;
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

        }



        static void Main(string[] args)
        {
            int[,] nums1 = new int[,] { { 0, -1, 2 }, { 3, -4, 5 }, { 0, 1, -2 } };
            int[,] nums2 = new[,] { { 0, 1, 2 }, { 3, 4, 5 },{ 3, 4, 5 } };
            int[,] nums3 = { { 0, 1, 2 }, { 3, 4, 5 } };
            Matrix matrixOne = new Matrix(nums1);
            Matrix matrixTwo = new Matrix(5,5);
            Matrix matrixThree = new Matrix(nums2);
            Matrix matrixFour = new Matrix(nums1);
            matrixOne.print();
            matrixOne.Negative();
            matrixOne.print();
            matrixTwo.print();
            matrixThree.print();
            Matrix matrixSum = new Matrix(matrixOne + matrixThree);
            matrixSum.print();
            
            Console.WriteLine(matrixOne == matrixFour);
            
            matrixOne--;
            matrixOne.print();


        }
    }
}
