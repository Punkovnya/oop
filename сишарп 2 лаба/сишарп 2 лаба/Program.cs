using System;
using System.Collections.Specialized;
using System.Text;
    
namespace сишарп_2_лаба
{
    class Program
    {
        static void Main(string[] args)
        {

            (int,int,int,char) tuple(int[] mas, string word)
            {
                int max=0, min=0,sum=0;
                for(int i = 0; i < mas.Length; i++)
                {
                    sum += mas[i];
                    if (max < mas[i])
                        max = mas[i];
                }
                for (int i = 0; i < mas.Length; i++)
                {
                    if (min > mas[i])
                        min = mas[i];
                }
                var MainTuple = (min, max,sum,word[0]);
                return MainTuple;
            }
            int Chck() {

                checked
                {
                   // short n = (short)(326593);
                }
                return 0;
            }
            int UnChck()
            {

                unchecked
                {
                    short n = (short)(326593);
                }
                return 0;
            }
            // bool
            bool check = true; // 1
            Console.WriteLine(check ? "Checked\n" : "Not checked\n");
            // sbyte = short byte -128 127
            sbyte sByteVar = 125;
            // byte ( from 0 to 255)
            byte byteVar = 255;
            // short (from -32768 to 32767)
            short shortVar = 32767;
            // ushort (from 0 to 65535)
            ushort ushortVar = 65535;
            // int (from -2,147,483,648 to 2,147,483,647)
            int intVar = 21477;
            // uint = unsigned int (from 0 to 4,294,967,295)
            uint uintVar = 4294967295;
            // long (from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807)
            long longVar = 9223372036854775807;
            // ulong (from 0 to 18,446,744,073,709,551,615)
            ulong ulongVar = 18446744073709551615;
            // floating point
            // float
            float floatVar = 4.8f;
            // double
            double doubleVar = 4.88;
            // decimal
            decimal decimalVar = 4.3247238M;
            // char
            var V = 33;
            char letter = 'a';
            object objDouble = doubleVar; // упаковка 
            double dObjectTo = (double)objDouble; // распаковка
            int shortVarToInt = shortVar;
            short byteVarToShort = byteVar;
            long intVarToLong = intVar;
            double floatVarToDouble = doubleVar;
            ulong uintVarToUlong = uintVar;
            decimal doubleVarToDecimal = (decimal)doubleVar;
            short intVarToshort = (short)intVar;
            byte ShortVarToByte = (byte)shortVar;
            byte intVarToByte = (byte)intVar;
            byte uintVarToByte = (byte)uintVar;
            int? z1 = 5;
            int iNumber = System.Convert.ToInt32(doubleVar);
            Console.WriteLine("sbyte " + sByteVar + '\n');
            Console.WriteLine("byte " + byteVar + '\n');
            Console.WriteLine("short " + shortVar + '\n');
            Console.WriteLine("ushort " + ushortVar + '\n');
            Console.WriteLine("int " + intVar + '\n');
            Console.WriteLine("uint " + uintVar + '\n');
            Console.WriteLine("long " + longVar + '\n');
            Console.WriteLine("long " + ulongVar + '\n');
            Console.WriteLine("float " + floatVar + '\n');
            Console.WriteLine("double " + doubleVar + '\n');
            Console.WriteLine("decimal " + decimalVar + '\n');
            Console.WriteLine("float " + floatVar + '\n');
            Console.WriteLine("double " + doubleVar + '\n');
            Console.WriteLine("decimal " + decimalVar + '\n');
            Console.WriteLine("char " + letter + '\n'+'\n');
            Console.WriteLine("shortVarToInt " + shortVarToInt + '\n');
            Console.WriteLine("byteVarToShort " + byteVarToShort + '\n');
            Console.WriteLine("intVarToLong " + intVarToLong + '\n');
            Console.WriteLine("floatVarToDouble " + floatVarToDouble + '\n');
            Console.WriteLine("uintVarToUlong " + uintVarToUlong + '\n'+'\n');


            Console.WriteLine("Неявный тип переменной " + V + '\n');
            Console.WriteLine("doubleVarToDecimal " + doubleVarToDecimal + '\n');
            Console.WriteLine("intVarToshort " + intVarToshort + '\n');
            Console.WriteLine("ShortVarToByte " + ShortVarToByte + '\n');
            Console.WriteLine("intVarToByte " + intVarToByte + '\n');
            Console.WriteLine("uintVarToByte " + uintVarToByte + '\n');
            Console.WriteLine("iNumber  " + iNumber + '\n');

            string strLit = "I am";
            string strLitAn = " string ";
            string strLitAnAn = "literal number ";
            Console.WriteLine(String.Compare(strLit, strLitAn));
            string s4 = String.Concat(strLit,strLitAn,strLitAnAn );
            Console.WriteLine(s4);
            string text = " hello world i am some sad ii ";
            string text2  = " hello world y am some sad ii ";
            if (text == text2)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            

            text = text.Insert(8,strLitAn);
            Console.WriteLine(text);
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            text =text.Remove(15);
            Console.WriteLine(text);
            text = text.Replace("string", "traffic");
            
            Console.WriteLine(text);
            Console.WriteLine($"this is anima{text}");
            string s2 = "not void";
            string s3 = null;
            Console.WriteLine("s2 = "+String.IsNullOrEmpty(s2) + " s3 = "+ String.IsNullOrEmpty(s3));
            StringBuilder MyText = new StringBuilder("This is when ");
            Console.WriteLine(MyText);
            MyText.Append("you know who your real friends are");
            
            MyText.Insert(0, "We are forever ");
            Console.WriteLine(MyText);
            MyText.Remove(0, 15);
            Console.WriteLine(MyText);
            int[,] DoubleNarray = { { 1, 2, 3}, { 2, 1, 3 }, { 3, 2, 4} };
            int rows = DoubleNarray.GetUpperBound(0) + 1;
            int columns = DoubleNarray.Length / rows;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{DoubleNarray[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int[] Arr = {1,23,4,5,6,7,8,9,0};
            
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.Write($"{Arr[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine("Длина- "+Arr.Length);
            int pos, val;
            Console.WriteLine("Выберите позицию элемента,которого нужно поменять");
            pos = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите новое значение "+pos+"- элемента");
            val = Convert.ToInt32(Console.ReadLine());
            Arr[pos] = val;
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.Write($"{Arr[i]} ");
            }

            Console.Write("\n"+"\n");
            double[][] numbers = new double[3][];
            numbers[0] = new double[2];
            numbers[1] = new double[3];
            numbers[2] = new double[4];
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("Введите элементы первой строки");
                    int elem = Convert.ToInt32(Console.ReadLine());
                    numbers[0][i] = elem;

                }
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите элементы второй строки");
                int elem = Convert.ToInt32(Console.ReadLine());
                numbers[1][i] = elem;

            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Введите элементы третьей строки");
                int elem = Convert.ToInt32(Console.ReadLine());
                numbers[2][i] = elem;

            }



            foreach (double[] row in numbers)
            {
                foreach (double number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // перебор с помощью цикла for
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Console.Write($"{numbers[i][j]} \t");
                }
                Console.WriteLine();
            }
            var array = new object[0];
            var str = "";

            var cort= (23, "ice age", 'c', "coming", 2235436475);
            var cortTwo = (231, "ice age", 'c', "coming", 2235436475);
            Console.WriteLine($"{cort.Item1} {cort.Item2} {cort.Item3}");
            Console.WriteLine($"{cort}");

            var ( q, w, e, r,t) = cort;
             (var qe, var we, var ee, var re, var te) = cort;
            (int qr, string wr, char er, string rr, ulong tr) = cort;
            if (cort == cortTwo)
                Console.WriteLine("Equals");
            else
                Console.WriteLine("Not equals");
            Console.WriteLine(tuple(Arr, "Ice age coming"));
            Chck(); UnChck();
        }
        
    }
    
}
