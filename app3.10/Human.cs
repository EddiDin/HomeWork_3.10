using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    /// <summary>
    /// Игрок человек. Имплементирует IPlayer
    /// </summary>
    class Human : IPlayer
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип игрока
        /// </summary>
        public short Type { get; set; }

        /// <summary>
        /// Конструктор игрока человека
        /// </summary>
        /// <param name="name">Имя игрока</param>
        public Human(string name)
        {
            this.Name = name;
            this.Type = 1;
        }

        /// <summary>
        /// Ход игрока
        /// </summary>
        /// <param name="gameNumber">Число gameNumber на момент хода</param>
        /// <param name="countPlayers">Кол-во игроков</param>
        /// <param name="minUserTry">Минимальное возможное значение для userTry</param>
        /// <param name="maxUserTry">Максимальное возможное значение для userTry</param>
        /// <returns>Положительное число (userTry)</returns>
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

                userTry = parsedInput;
            }

            return userTry;
        }
    }
}
