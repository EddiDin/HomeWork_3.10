using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    class PlayersFactory
    {
        public PlayersFactory() { }

        public IPlayer CreateHuman() {
            Console.WriteLine("Введите имя игрока:");
            string userInput = Console.ReadLine();
            return new Human(userInput);
        }

        public IPlayer CreateComputer(int computersCount) {
            string computerName = $"Компьютер__{computersCount}";
            return new Computer(computerName);
        }
    }
}
