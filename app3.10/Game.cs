using System;
using System.Collections.Generic;
using System.Text;

namespace app3._10
{
    class Game
    {

        public Game() { }

        public static void Start()
        {
            string header = $"Новая игра.";
            string divider = "----------------------------------------------------";
            Console.SetCursorPosition((Console.WindowWidth - header.Length) / 2, Console.CursorTop);
            Console.WriteLine(header);
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine("Правила:");
            Console.WriteLine("* Генерируется случайное число из заданного диапазона. Назовём его gameNumber.");
            Console.WriteLine("* Игроки по очереди выбирают число в заданном вами далее диапазоне. Назовем его userTry.");
            Console.WriteLine("* UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.");
            Console.WriteLine("* Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем.");
            Console.SetCursorPosition((Console.WindowWidth - divider.Length) / 2, Console.CursorTop);
            Console.WriteLine(divider);
            Console.WriteLine();
            Console.Beep();

            // Переменная для получения пользовательского ввода
            string userInput;

            // Генерация числа
            Console.WriteLine("Введите начало диапазона для генерации числа gameNumber:");
            int startForGameNumber = Game.GetStartForGameNumber();
            Console.WriteLine("Введите конец диапазона для генерации числа gameNumber:");
            int endForGameNumber = Game.GetEndForGameNumber(startForGameNumber);

            // Инициализация диапазона для userTry
            Console.WriteLine("Введите минимальное значение для userTry:");
            int minUserTry = Game.GetMinUserTry();
            Console.WriteLine("Введите максимальное значение для userTry:");
            int maxUserTry = Game.GetMaxUserTry(minUserTry);

            Random randomize = new Random();
            int gameNumber = randomize.Next(startForGameNumber, endForGameNumber + 1);

            Console.WriteLine($"Загаданное число: {gameNumber}");
            Console.WriteLine($"Возможный диапазон для userTry: от {minUserTry} до {maxUserTry}");

            Console.WriteLine();

            Console.WriteLine("Введите кол-во игроков от 2-ух до 5:");
            userInput = Console.ReadLine();
            short countPlayers = Int16.Parse(userInput);

            short successfullyAddedPlayers = 0;
            short computersCount = 0;
            PlayersFactory playersFactory = new PlayersFactory();
            PlayersList playersList = new PlayersList();

            // MOCK (для отладки)
            /*for (int i = 0; i < countPlayers; i++)
            {
                IPlayer player = playersFactory.CreateComputer(i + 1);
                playersList.Add(player);
            }*/

            while (successfullyAddedPlayers < countPlayers)
            {
                Console.WriteLine();
                Console.WriteLine($"Создание {successfullyAddedPlayers + 1} игрока:");
                Console.WriteLine("Введите тип игрока: 1 - Живой игрок; 2 - Игрок компьютер (легкий/совсем тупой); 3 - Игрок компьютер (посложнее).");
                userInput = Console.ReadLine();

                sbyte playerType = -1;
                while (playerType == -1)
                {
                    bool successParse = SByte.TryParse(userInput, out sbyte parsedInput);
                    if (!successParse || parsedInput < 1 || parsedInput > 3)
                    {
                        Console.WriteLine($"Необходимо ввести тип игрока (1, 2 или 3). Попробуйте еще раз...");
                        continue;
                    }

                    playerType = parsedInput;
                }

                IPlayer player;

                switch (playerType)
                {
                    case 1:
                        player = playersFactory.CreateHuman();
                        break;
                    case 2:
                    case 3:
                        computersCount++;
                        player = playersFactory.CreateComputer(computersCount, playerType);
                        break;
                    default:
                        player = playersFactory.CreateHuman();
                        break;
                }

                playersList.Add(player);
                successfullyAddedPlayers++;
            }

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
                int userTry = player.Move(gameNumber, countPlayers, minUserTry, maxUserTry);
                Console.WriteLine($"Игрок {player.Name} ввел число {userTry}.");
                gameNumber -= userTry;
                Console.WriteLine($"gameNumber теперь равно {gameNumber}");
                lastPlayerName = player.Name;
                currentPlayerIndex++;
                if (currentPlayerIndex >= countPlayers) currentPlayerIndex = 0;
            }

            Console.WriteLine();
            Console.WriteLine($"Игра окончена! Победитель {lastPlayerName}!");

            Console.WriteLine();
            Console.WriteLine("Хотите ли вы сыграть снова? (Y - да/ N - нет)");
            while (true)
            {
                string isRevenge = Console.ReadLine();
                if (isRevenge.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    Game.Start();
                    break;
                }

                if (isRevenge.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                Console.WriteLine("Введите \"Y\", если хотите переиграть или \"N\", если хотите выйти из игры ...");
            }
        }

        public static int GetStartForGameNumber()
        {
            int startForGameNumber = -1;

            while (startForGameNumber == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Начало диапазона должно быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput < 0)
                {
                    Console.WriteLine("Начало диапазона должно быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                startForGameNumber = parsedInput;
            }

            return startForGameNumber;
        }

        public static int GetEndForGameNumber(int startForGameNumber)
        {
            int endForGameNumber = -1;

            while (endForGameNumber == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Конец диапазона должен быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput < 0)
                {
                    Console.WriteLine("Конец диапазона должен быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput < startForGameNumber)
                {
                    Console.WriteLine($"Конец диапазона должен быть больше начала (начало = {startForGameNumber}). Попробуйте еще раз...");
                    continue;
                }

                endForGameNumber = parsedInput;
            }

            return endForGameNumber;
        }

        public static int GetMinUserTry()
        {
            int minUserTry = -1;

            while (minUserTry == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Минимальное значение для userTry должно быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput <= 0)
                {
                    Console.WriteLine("Минимальное значение для userTry должно быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                minUserTry = parsedInput;
            }

            return minUserTry;
        }

        public static int GetMaxUserTry(int minUserTry)
        {
            int maxUserTry = -1;

            while (maxUserTry == -1)
            {
                string userInput = Console.ReadLine();
                bool successParse = Int32.TryParse(userInput, out int parsedInput);
                if (!successParse)
                {
                    Console.WriteLine("Максимальное значение для userTry должно быть числом. Попробуйте еще раз...");
                    continue;
                }

                if (parsedInput <= 0)
                {
                    Console.WriteLine("Максимальное значение для userTry должно быть больше 0. Попробуйте еще раз...");
                    continue;
                }

                if ((parsedInput - minUserTry) < 3)
                {
                    Console.WriteLine("Максимальное значение для userTry должно быть больше минимального хотя бы на 3. Попробуйте еще раз...");
                    continue;
                }

                maxUserTry = parsedInput;
            }

            return maxUserTry;
        }
    }
}
