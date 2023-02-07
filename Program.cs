using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloWold
{
    public static class Program
    {
        

        public static void Main()
        {
           
          //  int i, k, a = 0;
            /** Перечень ключевых символов  **/
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] operators = new char[] { '+', '-', '*', '/' };
            char[] bracketsStart = new char[] { '(', '{', '[' };
            char[] bracketsEnd = new char[]{')', '}', ']' };
            char[] delimiter = new char[] { '.', ',' };

            /** Исходное уравнение **/
            string equation="";
            /** Собираемое число**/
            string number = "";
            /** Количетсво чисел **/
            int countNumber = 0;
            /** Массив найденных чисел **/
            double[] valuesEquation = new double[255];
            /** Количетсво операторов **/
            int countOperators = 0;
            /** Массив найденных операторов **/
            char[] operatorsEquation = new char[255];
            
            /*** Ввод данных **/
            Console.WriteLine("Калькулятор");
            Console.WriteLine("");
            Console.WriteLine("Введите числовое выражение -  ");
            equation = Console.ReadLine();
            /** Вычисления **/
            
            int k = equation.Length;
            for (int i = 0; i < k; i++)
            {

                if (Array.IndexOf(numbers, equation[i]) > -1)
                {
                    number += equation[i].ToString();
                }
                else if (Array.IndexOf(operators, equation[i]) > -1)
                {
                    if (number.Length > 0)
                    {
                        valuesEquation[countNumber] = Convert.ToDouble(number);
                        countNumber++;
                        number = "";
                    }
                    operatorsEquation[countOperators] = equation[i];
                    countOperators++;
                }

            }

            if (number.Length > 0)
            {
                valuesEquation[countNumber] = Convert.ToDouble(number);
                countNumber++;
                number = "";
            }



            for (int i=0;i<countNumber; i++)
            {
                Console.WriteLine(valuesEquation[i].ToString());
                Console.WriteLine(operatorsEquation[i].ToString());
            }
        }
    }
}