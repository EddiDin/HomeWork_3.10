using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    class Computer : IPlayer
    {
        public string Name { get; set; }

        public short Type { get; set; }

        public Computer(string name)
        {
            this.Name = name;
            this.Type = 2;
        }

        public int Move(int gameNumber, int countPlayers)
        {
            if (gameNumber >= 1 && gameNumber <= 4)
            {
                return gameNumber;
            }

            Random randomize = new Random();

            return randomize.Next(1, 5);
        }
    }
}
