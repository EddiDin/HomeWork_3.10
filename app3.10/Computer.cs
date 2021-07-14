using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    class Computer : IPlayer
    {
        public string Name { get; set; }

        public short Type { get; set; }

        public Computer(string name, sbyte computerType)
        {
            this.Name = name;
            this.Type = computerType;
        }

        public int Move(int gameNumber, int countPlayers, int minUserTry, int maxUserTry)
        {
            if (this.Type == 2)
            {
                return this.MoveEasy(gameNumber, countPlayers, minUserTry, maxUserTry);
            }

            return this.MoveMiddle(gameNumber, countPlayers, minUserTry, maxUserTry);


        }

        private int MoveEasy(int gameNumber, int countPlayers, int minUserTry, int maxUserTry) {
            return minUserTry;
        }

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
