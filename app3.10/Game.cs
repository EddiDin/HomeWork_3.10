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

        public static int GetMinUserTry()
        {
            int minUserTry = -1;

            while (minUserTry == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Минимальное значение для userTry должно быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput <= 0)
                {
                    Console.WriteLine("Минимальное значение для userTry должно быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                minUserTry = parsedInput;
            }

            return minUserTry;
        }

        public static int GetMaxUserTry(int minUserTry)
        {
            int maxUserTry = -1;

            while (maxUserTry == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Максимальное значение для userTry должно быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput <= 0)
                {
                    Console.WriteLine("Максимальное значение для userTry должно быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                if ((parsedInput - minUserTry) < 3)
                {
                    Console.WriteLine("Максимальное значение для userTry должно быть больше минимального хотя бы на 3. Попробуйте еще раз...");
                    continue;
                }

                maxUserTry = parsedInput;
            }

            return maxUserTry;
        }
    }
}
