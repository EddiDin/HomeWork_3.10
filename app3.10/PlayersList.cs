using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    /// <summary>
    /// Репозиторий игроков
    /// </summary>
    class PlayersList
    {
        /// <summary>
        /// Список игроков
        /// </summary>
        public List<IPlayer> Players { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public PlayersList()
        {
            this.Players = new List<IPlayer>();
        }

        /// <summary>
        /// Добавление нового игрока
        /// </summary>
        /// <param name="player">Объект класса имплеминтирующего IPlayer</param>
        public void Add(IPlayer player)
        {
            this.Players.Add(player);
        }

        /// <summary>
        /// Получение кол-ва игроков
        /// </summary>
        /// <returns>Число - кол-во игроков</returns>
        public int GetCount()
        {
            return this.Players.Count;
        }

        /// <summary>
        /// Отформатированный вывод списка игроков
        /// </summary>
        public void PrintList()
        {
            string pattern = "Имя: {0}";
            foreach (IPlayer player in this.Players)
            {
                Console.WriteLine(pattern, player.Name);
            }
        }

        /// <summary>
        /// Получение игрока из списка по его индексу
        /// </summary>
        /// <param name="index">Индекс игрока</param>
        /// <returns>Игрок</returns>
        public IPlayer GetPlayer(int index)
        {
            return this.Players[index];
        }
    }
}
