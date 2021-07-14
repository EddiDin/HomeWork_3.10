using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    interface IPlayer
    {
        public string Name { get; set; }
        public int Move(int gameNumber, int countPlayers, int minUserTry, int maxUserTry);
    }
}
