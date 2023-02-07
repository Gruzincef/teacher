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
            /** Флаг вещественное число**/
            bool realNumber = false;
            /** Знак числа **/
            bool numberSign = false;
            /** Результат вычислений **/
            double res = 0;
            /*** Ввод данных **/
            Console.WriteLine("Калькулятор");
            Console.WriteLine("");
            Console.WriteLine("Введите числовое выражение -  ");
            equation = Console.ReadLine();
            /** Вычисления **/
            
            int k = equation.Length;
            for (int i = 0; i < k; i++)
            {
            //Формируем число
                if (Array.IndexOf(numbers, equation[i]) > -1)
                {
                    number += equation[i].ToString();
                }
            //Если попался знак точка или запятая, запоминаем сей факт, если несколько знаков подряд игнорируем их
                else if ((Array.IndexOf(delimiter, equation[i]) > -1)&&(!realNumber))
                {
                    realNumber = true;
                    number += ",";
                }
            //Определяем оператор 
                else if (Array.IndexOf(operators, equation[i]) > -1)
                {
                    if (number.Length > 0)
                    {
                        valuesEquation[countNumber] = Convert.ToDouble(number);
                        countNumber++;
                        number = "";
                        realNumber = false;
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

            if (countNumber != countOperators + 1)
            {
                Console.WriteLine("Ошибка в записи ");

            }
            else
            {
                //Вывод
                for (int i = 0; i < countNumber; i++)
                {
                    Console.Write(valuesEquation[i].ToString());
                    Console.Write(operatorsEquation[i].ToString());
                }
                Console.WriteLine("");
                //перемножение и деление
                for (int i = 0; i < countNumber; i++)
                {
                    if(operatorsEquation[i]=='*')
                    {
                        valuesEquation[i] = valuesEquation[i] * valuesEquation[i + 1];
                        valuesEquation[i + 1] = 0;
                        operatorsEquation[i] = '+';
                    }
                    else if (operatorsEquation[i] == '/')
                    {
                        valuesEquation[i] = valuesEquation[i] / valuesEquation[i + 1];
                        valuesEquation[i + 1] = 0;
                        operatorsEquation[i] = '+';
                    }
                }
   
                //Вывод
                for (int i = 0; i < countNumber; i++)
                {
                    Console.Write(valuesEquation[i].ToString());
                    Console.Write(operatorsEquation[i].ToString());
                }

                res = valuesEquation[0];
                //перемножение и деление
                for (int i = 0; i < countNumber; i++)
                {
                    if (operatorsEquation[i] == '+')
                    {
                        res += valuesEquation[i+1];
                    }
                    else if (operatorsEquation[i] == '-')
                    {
                        res -= valuesEquation[i + 1];
                    }
                }
                Console.WriteLine("");
                Console.Write("Ответ: "+res);
            }
        }
    }
}