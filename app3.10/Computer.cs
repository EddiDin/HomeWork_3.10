using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    /// <summary>
    /// Игрок компьютер. Имплементирует IPlayer
    /// </summary>
    class Computer : IPlayer
    {
        /// <summary>
        /// Имя игрока компьютера
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип игрока
        /// </summary>
        public short Type { get; set; }

        /// <summary>
        /// Конструктор игрока компьютера.
        /// </summary>
        /// <param name="name">Имя игрока компьютера</param>
        /// <param name="computerType">Тип игрока</param>
        public Computer(string name, sbyte computerType)
        {
            this.Name = name;
            this.Type = computerType;
        }

        /// <summary>
        /// Ход компьютера
        /// </summary>
        /// <param name="gameNumber">Число gameNumber на момент хода</param>
        /// <param name="countPlayers">Кол-во игроков</param>
        /// <param name="minUserTry">Минимальное возможное значение для userTry</param>
        /// <param name="maxUserTry">Максимальное возможное значение для userTry</param>
        /// <returns>Положительное число (userTry)</returns>
        public int Move(int gameNumber, int countPlayers, int minUserTry, int maxUserTry)
        {
            if (this.Type == 2)
            {
                return this.MoveEasy(gameNumber, countPlayers, minUserTry, maxUserTry);
            }

            return this.MoveMiddle(gameNumber, countPlayers, minUserTry, maxUserTry);


        }

        /// <summary>
        /// Ход "легкого" компьютера
        /// </summary>
        /// <param name="gameNumber">Число gameNumber на момент хода</param>
        /// <param name="countPlayers">Кол-во игроков</param>
        /// <param name="minUserTry">Минимальное возможное значение для userTry</param>
        /// <param name="maxUserTry">Максимальное возможное значение для userTry</param>
        /// <returns>Положительное число (userTry)</returns>
        private int MoveEasy(int gameNumber, int countPlayers, int minUserTry, int maxUserTry)
        {
            return minUserTry;
        }

        /// <summary>
        /// Ход "среднего" компьютера
        /// </summary>
        /// <param name="gameNumber">Число gameNumber на момент хода</param>
        /// <param name="countPlayers">Кол-во игроков</param>
        /// <param name="minUserTry">Минимальное возможное значение для userTry</param>
        /// <param name="maxUserTry">Максимальное возможное значение для userTry</param>
        /// <returns>Положительное число (userTry)</returns>
        private int MoveMiddle(int gameNumber, int countPlayers, int minUserTry, int maxUserTry)
        {
            if (gameNumber >= minUserTry && gameNumber <= maxUserTry)
            {
                return gameNumber;
            }

            Random randomize = new Random();

            return randomize.Next(minUserTry, maxUserTry + 1);
        }
    }
}
