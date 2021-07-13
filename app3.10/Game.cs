using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    class Game
    {

        public Game() { }

        public static int GetStartForGameNumber()
        {
            int startForGameNumber = -1;

            while (startForGameNumber == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Начало диапазона должно быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput < 0)
                {
                    Console.WriteLine("Начало диапазона должно быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                startForGameNumber = parsedInput;
            }

            return startForGameNumber;
        }

        public static int GetEndForGameNumber(int startForGameNumber)
        {
            int endForGameNumber = -1;

            while (endForGameNumber == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Конец диапазона должен быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput < 0)
                {
                    Console.WriteLine("Конец диапазона должен быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput < startForGameNumber)
                {
                    Console.WriteLine($"Конец диапазона должен быть больше начала (начало = {startForGameNumber}). Попробуйте еще раз...");
                    continue;
                }

                endForGameNumber = parsedInput;
            }

            return endForGameNumber;
        }
    }
}
