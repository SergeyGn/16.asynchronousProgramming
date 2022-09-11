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
        //ответ 900_000
        private static int _number1 = 1_000_000;
        private static int _number2 = 2_000_000;
        private static int _quantityNumber = 0;
        private static int c = 0;
        private static int _countThread;
        private static int _activCountThread=0;
        private static object _locker=new object();
        static void Main(string[] args)
        {
            DateTime time1 = DateTime.Now; //удалить

            //ThreadPool.GetAvailableThreads(out countThread, out int completionPortThreads); //находим количество доступных потоков и засовываем в countThread 
            _countThread = 10;
            int quantityNum = _number2 - _number1; //количество чисел
            int quantityPat = quantityNum / _countThread; //находим часть от количества чисел которую можно взять в один поток 

            for (int i = 0; i < _countThread; i++)
            {
                int startNumber = i * quantityPat + _number1;
                Thread _receiveThread = new Thread(delegate () { Calculate(startNumber, startNumber + quantityPat); });
                _receiveThread.Start();
                _activCountThread++;
                if (_countThread == _activCountThread)
                {
                   
                }
            }
            while(c<_countThread)
            {
                Thread.Sleep(10);
            }
            GetDisplay(_quantityNumber);

            DateTime time2 = DateTime.Now; //удалить
            double countTime = (time2 - time1).TotalSeconds; //удалить
            Console.WriteLine($"Количество секунд :{countTime}"); //удалить

            Console.ReadLine();
        }


        static void Calculate(int min, int max)
        {
            

            //остатком от деления найти последнее число и все оставшиеся
            for (int i = min; i <= max; i++)
            {
                int currentNumber;
                currentNumber = i;

                int lastNumber = (currentNumber % 10);//нашли последнию цифру от числа
                int sum=0;
                while(currentNumber>0)
                {
                    currentNumber /= 10;
                    //Console.WriteLine(currentNumber % 10);
                    sum += currentNumber % 10;
                }
                sum += lastNumber;
                if (lastNumber != 0)
                {
                    lock (_locker) //пока один поток не запишет в переменную _quantityNumber другие не станут записывать
                    {
                        _quantityNumber++;
                    }
                }
            }
            c++;
        }

        static void GetDisplay(int quantityNumber)
        {
            Console.WriteLine($"Кол-во чисел удовлетворяющих условию = {quantityNumber}");
        }
    }

}
