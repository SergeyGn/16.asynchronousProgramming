using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _16.asynchronousProgramming
{
    class Program
    {
        //вычислить количество чисел на промежутке от 1_000_000 до 2_000_000 в котором сумма цифр будет кратна последней цифре без остатка
        private static int _number1 = 1_000_000;
        private static int _number2 = 2_000_000;
        private static int _quantityNumber1 = 0;
        private static int _quantityNumber2 = 0;
        static void Main(string[] args)
        {
            
           Thread _receiveThread = new Thread(new ThreadStart(Сalculate1));
            _receiveThread.Start();
            Thread _receiveThread2 = new Thread(new ThreadStart(Сalculate2));
            _receiveThread2.Start();

            Console.ReadLine();
        }
        static void Сalculate1()
        {
            string currentNumber;
            int result = 0;

            for (int i = _number1; i < (_number1+_number2)/2; i++)
            {
                currentNumber = i.ToString();
                int sum = 0;

                for (int j = 0; j < currentNumber.Length; j++)
                {
                    string current = currentNumber[j].ToString();
                    sum += int.Parse(current);

                }
                string lastNumber = currentNumber[currentNumber.Length - 1].ToString();
                int multiplier = int.Parse(lastNumber);

                if (multiplier != 0)
                {
                    if (sum % multiplier == 0)
                    {
                        result++;
                    }

                }
            }
            _quantityNumber1 = result;
            if(_quantityNumber2>0)
            {
                Console.WriteLine($"Количество чисел на промежутке от {_number1} до {_number2} в котором сумма цифр будет " +
                $"\nкратна последней цифре без остатка равна:" +
                $"\n{_quantityNumber1+ _quantityNumber2}");
            }
        }

        static void Сalculate2()
        {
            string currentNumber;
            int result = 0;

            for (int i = (_number1 + _number2) / 2; i <= _number2; i++)
            {
                currentNumber = i.ToString(); 
                int sum = 0;

                for (int j = 0; j < currentNumber.Length; j++)
                {
                    string current = currentNumber[j].ToString();
                    sum += int.Parse(current);

                }
                string lastNumber = currentNumber[currentNumber.Length - 1].ToString();
                int multiplier = int.Parse(lastNumber);

                if (multiplier != 0)
                {
                    if (sum % multiplier == 0)
                    {
                        result++;
                    }

                }
            }
            _quantityNumber2 = result;
            if (_quantityNumber1 > 0)
            {
                Console.WriteLine($"Количество чисел на промежутке от {_number1} до {_number2} в котором сумма цифр будет " +
                $"\nкратна последней цифре без остатка равна:" +
                $"\n{_quantityNumber1 + _quantityNumber2}");
            }
        }
    }
}
