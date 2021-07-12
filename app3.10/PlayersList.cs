using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    class PlayersList
    {
        public List<IPlayer> Players { get; set; }

        public PlayersList()
        {
            this.Players = new List<IPlayer>();
        }

        public void Add(IPlayer player)
        {
            this.Players.Add(player);
        }

        public int GetCount()
        {
            return this.Players.Count;
        }

        public void PrintList()
        {
            string pattern = "Имя: {0}";
            foreach (IPlayer player in this.Players)
            {
                Console.WriteLine(pattern, player.Name);
            }
        }

        public IPlayer GetPlayer(int index)
        {
            return this.Players[index];
        }
    }
}
