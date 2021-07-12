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

        public int Move(int gameNumber, int countPlayers)
        {
            Console.WriteLine("Введите число:");
            string userInput = Console.ReadLine();

            return Int16.Parse(userInput);
        }
    }
}
