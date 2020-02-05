using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_CM
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            Console.WriteLine("Input number: ");
            string sinput = Console.ReadLine();

            if (sinput.Substring(0, 1) == "0")
            {

                if (sinput.Substring(1, 1) == "x")
                {
                    string Hex = sinput.Substring(2, sinput.Length - 2);
                    menu(HexToDec(Hex));

                }
                else
                {
                    string Oct = sinput.Substring(1, sinput.Length - 1);
                    menu(OctToDec(Oct));
                    input = int.Parse(Oct);
                }

            }
            else
            {
                input = int.Parse(sinput);
                menu(input);
            }
            
        }
        public static void menu(int DecValue)
        {
            Console.WriteLine("Dec: " + Decimal(DecValue));

            Console.WriteLine("Bin: " + Bin(DecValue));

            Console.WriteLine("Oct: " + Oct(DecValue));

            Console.WriteLine("Hex: " + Hex(DecValue));

        }
        private static int HexToDec(string input)
        {
            int output = 0;
            try
            {
                //converting to integer
                output = Convert.ToInt32(input, 16);

                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;
        }

        private static int OctToDec(string input)
        {
            int output = 0;
            try
            {
                //converting to integer
                output = Convert.ToInt32(input, 8);

                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;
        }

        private static string Hex(int input)
        {
            string hex = "";
            string[] h = new string[] { "A", "B", "C", "D", "E", "F"};
            int loop = 0;

            while (input != 0)
            {
                if((input % 16) >= 10)
                {
                    hex = hex.Insert(0, h[(input % 16) - 10]);
                }
                double pow_ab = Math.Pow(10, loop);
                if((input % 16) < 10)
                {
                    hex = hex.Insert(0, (input % 16).ToString());
                }
                input = input / 16;
                loop++;
            }
            return hex;
        }

        private static double Oct(int input)
        {
            double oct = 0;
            int loop = 0;

            while (input != 0)
            {
                if (input % 8 != 0)
                {
                    double pow_ab = Math.Pow(10, loop);
                    oct = oct + (input % 8)* pow_ab;
                }
                input = input / 8;
                loop++;
            }
            return oct;
        }

        private static double Bin(int input)
        {
            double bin=0;
            int loop = 0;

            while (input != 0)
            {
                if (input % 2 != 0)
                {
                    double pow_ab = Math.Pow(10, loop);
                    bin = bin + pow_ab;
                }
                input = input / 2;
                loop++;
            }
            return bin;
        }

        private static double BinFraction(string input)
        {
            double bin = 0;
            int dot = input.IndexOf(".");
            int firstPart = int.Parse(input.Substring(0,dot-1));
            double secPart = double.Parse(input.Substring(dot+1,input.Length));

            bin = Bin(firstPart);

            for (int i = 0; i < input.Length; i++)
            {

            }

            return bin;
        }

        private static int Decimal(int input)
        {
            return input;
        }
    }
}
