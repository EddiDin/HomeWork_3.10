using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    /// <summary>
    /// Интерфейс игрока
    /// </summary>
    interface IPlayer
    {
        /// <summary>
        /// Имя игрока
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ход игрока
        /// </summary>
        /// <param name="gameNumber">Число gameNumber на момент хода</param>
        /// <param name="countPlayers">Кол-во игроков</param>
        /// <param name="minUserTry">Минимальное возможное значение для userTry</param>
        /// <param name="maxUserTry">Максимальное возможное значение для userTry</param>
        /// <returns>Положительное число (userTry)</returns>
        public int Move(int gameNumber, int countPlayers, int minUserTry, int maxUserTry);
    }
}
