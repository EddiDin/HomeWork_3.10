using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    class Human : IPlayer
    {
        public string Name { get; set; }

        public short Type { get; set; }

        public Human(string name)
        {
            this.Name = name;
            this.Type = 1;
        }

        public int Move(int gameNumber, int countPlayers, int minUserTry, int maxUserTry)
        {
            Console.WriteLine("Введите число:");
            int userTry = -1;

            while (userTry == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse || parsedInput < minUserTry || parsedInput > maxUserTry)
                {
                    Console.WriteLine($"Необходимо ввести число из заданного диапазона (от {minUserTry} до {maxUserTry}). Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput > gameNumber)
                {
                    Console.WriteLine($"Введенное число больше чем gameNumber ({gameNumber}). Попробуйте еще раз...");
                    continue;
                }

                userTry = parsedInput;
            }

            return userTry;
        }
    }
}
