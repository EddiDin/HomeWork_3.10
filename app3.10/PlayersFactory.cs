using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    /// <summary>
    /// Фабрика создания игроков
    /// </summary>
    class PlayersFactory
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PlayersFactory() { }

        /// <summary>
        /// Метод создания игрока человека
        /// </summary>
        /// <returns>Игрок человек</returns>
        public IPlayer CreateHuman() {
            Console.WriteLine("Введите имя игрока:");
            string userInput = Console.ReadLine();
            return new Human(userInput);
        }

        /// <summary>
        /// Метод создания игрока компьютера
        /// </summary>
        /// <param name="computersCount">Индекс игрока компьютера (для генерации имени)</param>
        /// <param name="computerType">Тип игрока компьютера (сложность)</param>
        /// <returns>Игрок компьютер</returns>
        public IPlayer CreateComputer(int computersCount, sbyte computerType) {
            string computerName = $"Компьютер__{computersCount}";
            return new Computer(computerName, computerType);
        }
    }
}
