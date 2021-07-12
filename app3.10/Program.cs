using System;

namespace app3._10
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomize = new Random();

            int gameNumber = randomize.Next(12, 121);

            string userInput;

            string header = $"Новая игра.";
            string divider = "----------------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(header);
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine("Правила:");
            Console.WriteLine("* Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.");
            Console.WriteLine("* Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.");
            Console.WriteLine("* UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.");
            Console.WriteLine("* Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.");
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine();

            Console.WriteLine($"Загаданное число: {gameNumber}");

            Console.WriteLine("Введите кол-во игроков от 2-ух до 5:");
            userInput = Console.ReadLine();
            short countPlayers = Int16.Parse(userInput);


            short successfullyAddedPlayers = 0;
            short computersCount = 0;
            PlayersFactory playersFactory = new PlayersFactory();
            PlayersList playersList = new PlayersList();

            // MOCK
            for (int i = 0; i < countPlayers; i++)
            {
                IPlayer player = playersFactory.CreateComputer(i + 1);
                playersList.Add(player);
            }

            /*while (successfullyAddedPlayers < countPlayers)
            {
                Console.WriteLine();
                Console.WriteLine($"Создание {successfullyAddedPlayers + 1} игрока:");
                Console.WriteLine("Введите тип игрока: 1 - Живой игрок; 2 - Игрок компьютер.");
                userInput = Console.ReadLine();
                short playerType = Int16.Parse(userInput);
                IPlayer player;
                if (playerType == 1)
                {
                    player = playersFactory.CreateHuman();
                }
                else
                {
                    computersCount++;
                    player = playersFactory.CreateComputer(computersCount);
                }

                playersList.Add(player);
                successfullyAddedPlayers++;
            }*/

            Console.WriteLine();
            Console.WriteLine("Все игроки добавлены:");
            playersList.PrintList();


            // GAME
            int currentPlayerIndex = 0;
            string lastPlayerName = "";
            while (gameNumber > 0)
            {
                IPlayer player = playersList.GetPlayer(currentPlayerIndex);
                Console.WriteLine($"Ход игрока {player.Name}.");
                int userTry = player.Move(gameNumber, countPlayers);
                Console.WriteLine($"Игрок {player.Name} ввел число {userTry}.");
                gameNumber -= userTry;
                Console.WriteLine($"gameNumber теперь равно {gameNumber}");
                lastPlayerName = player.Name;
                currentPlayerIndex++;
                if (currentPlayerIndex >= countPlayers) currentPlayerIndex = 0;
            }

            Console.WriteLine();
            Console.WriteLine($"Игра окончена! Победитель {lastPlayerName}!");
        }
    }
}
