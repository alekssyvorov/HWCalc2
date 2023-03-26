using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWCalc2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter + - / * or root or degree");
            Console.WriteLine($"Result = {Calc(9.0f, 2.0f, "degree", false)}");
            Console.ReadLine();
        }

        public static float Calc(float firstOperant, float secndOperant, string operation, bool isRevers = false)
        {
            float result = 0;
            if (!isRevers)
            {
                switch (operation)
                {
                    case "+":
                        result = firstOperant + secndOperant;
                        break;
                    case "-":
                        result = firstOperant - secndOperant;
                        break;
                    case "*":
                        result = firstOperant * secndOperant;
                        break;
                    case "/":
                        try
                        {
                            result = firstOperant / secndOperant;
                        }
                        //Так как в используется деление с плавающей запятой, а
                        //не целочисленное деление, операция не создает DivideByZeroException исключение.
                        finally
                        {
                            Console.WriteLine("Division of {0} by zero.", secndOperant);
                        }
                        break;
                    case "root":
                        result = (float)Math.Pow((double)firstOperant, 1 / (double)secndOperant);
                        break;
                    case "degree":
                        result = (float)Math.Pow((double)firstOperant, (double)secndOperant);
                        break;
                }
            }
            else
            {
                switch (operation)
                {
                    case "+":
                        result = secndOperant + firstOperant;
                        break;
                    case "-":
                        result = secndOperant - firstOperant;
                        break;
                    case "*":
                        result = secndOperant * firstOperant;
                        break;
                    case "/":
                        try
                        {
                            result = secndOperant / firstOperant;
                        }
                        finally
                        {
                            Console.WriteLine("Division of {0} by zero.", firstOperant);
                        }
                        break;
                    case "root":
                        result = (float)Math.Pow((double)secndOperant, 1 / (double)firstOperant);
                        break;
                    case "degree":
                        result = (float)Math.Pow((double)secndOperant, (double)firstOperant);
                        break;
                }
            }
            return result;
        }
    }
}
