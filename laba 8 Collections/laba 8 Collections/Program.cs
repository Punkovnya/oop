using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace laba_8_Collections
{
    
    public sealed class Tu134
    {
        public string Weapon { get; set; }
        private int weight;
        public  int Id { get; set; }
        public  int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public Tu134(int Id, int Weight, string Weapon)
        {
            this.Weapon = Weapon;
            this.Weight = Weight;
            this.Id = Id;
        }
        public void ToString()
        {
            Console.WriteLine($"Вес самолета ТУ134 - {Weight}  , его Id  - {Id} , оружие - {Weapon}");
        }
    }
    interface IMatrix<T> where T: class
    {
        public int FirstNum(Matrix<int> matrix, int column)
        {
            int[,] mas = matrix.Mas; int number;
            number = mas[column, 0];
            return number;

        }
        public string FirstNum(Matrix<string> matrix, int column)
        {
            string[,] mas = matrix.Mas; string number;
            number = mas[column, 0];
            return number;

        }
        public static void Negative(Matrix<int> matrix)
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
    public abstract class TT<F>
    {

    }
    public class TF<F> : TT<F>
    {

    }
    public class Matrix<T>:IMatrix<Matrix<T>>
    {
        private T[,] mas;// поле
        public T[,] Mas
        {
            get
            {
                return mas;
            }
            set
            {
                mas = value;
            }


        }
        public Matrix(T[,] mas)
        {
            this.mas = mas;
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
        public void save()
        {
            int rows = Mas.GetUpperBound(0) + 1;
            int columns = Mas.Length / rows;


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    File.AppendAllText("file.txt",Convert.ToString(Mas[i, j]));
                    File.AppendAllText("file.txt","\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
        }



    }
    class Program
    {

        static void Main(string[] args)
        {
            Tu134 tu134_1 = new Tu134(12, 2000,"pulemets");
            Tu134 tu134_2 = new Tu134(13, 2000, "pulemets");
            Tu134 tu134_3 = new Tu134(14, 2000, "pulemets");
            Tu134 tu134_4 = new Tu134(15, 2000, "pulemets");
            Tu134 tu134_5 = new Tu134(16, 2000, "pulemets");
            Tu134 tu134_6 = new Tu134(17, 2000, "pulemets");
            int[,] nums1 = new int[,] { { 0, -1, 2 }, { 3, -4, -5 }, { 0, 1, -2 } };
            double[,] nums2 = new[,] { { 0.44, 1.32, 2.234 }, { 3.33, 4.123, 5.123 }, { 3.325423, 4.2351, 5.134315 } };
            string[,] str = { { "nicolaas", "jaar", "nicolaas" }, { "nicolas", "jaar", "nicolas" } };
            Tu134[,] tu134s = { { tu134_1, tu134_2 }, { tu134_3, tu134_4 }, { tu134_5, tu134_6 } };
            List<Matrix<string>> Matrix_String= new List<Matrix<string>>();
            List<Matrix<int>> Matrix_Int = new List<Matrix<int>>();
            List<Matrix<double>> Matrix_Double = new List<Matrix<double>>();
            List<Matrix<Tu134>> Matrix_Tu134 = new List<Matrix<Tu134>>();
            Matrix_Int.Add(new Matrix<int>(nums1));
            Matrix_Double.Add(new Matrix<double>(nums2));
            Matrix_String.Add(new Matrix<string>(str));
            Matrix_Tu134.Add(new Matrix<Tu134>(tu134s));

            Matrix<double> matrixTwo = new Matrix<double>(nums2);
            Matrix<string> matrixFour = new Matrix<string>(str);
            Console.WriteLine(Matrix_Tu134[0].Mas[0,1].Weapon);
            Matrix_Int[0].print();
            Matrix_Double[0].print();
            Matrix_String[0].print();
            Matrix_String[0].save();
            Console.WriteLine(((IMatrix<Matrix<int>>)Matrix_Int[0]).FirstNum(Matrix_Int[0],1));
            Console.WriteLine(((IMatrix<Matrix<string>>)Matrix_String[0]).FirstNum(Matrix_String[0], 1));






        }
    }
}
