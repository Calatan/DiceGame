using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static System.Console;

namespace Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(97, 30);

            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.White;
            Clear();

            Player[] playerList = new Player[4];

            int numberOfPlayers = 0;

            int numberOfThrows = 7;

            int counterThrows = 0;

            int maxSum = 0;

            WriteLine("*************************************************************************************************");
            WriteLine("*                                                                                               *");
            WriteLine("*   V Ä L K O M M E N   T I L L   K A S T A   E N T A L / T I O T A L   M E D   T Ä R N I N G   *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*************************************************************************************************");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*************************************************************************************************");

            SetCursorPosition(2, 7);
            Write("- Alla spelare måste kasta tärningen exakt sju gånger");
            SetCursorPosition(2, 8);
            Write("- Efter varje kast väljer spelaren om ögonen på tärningen skall räknas som ental eller tiotal");
            SetCursorPosition(2, 9);
            Write("- Summan för alla spelarens kast läggs ihop");
            SetCursorPosition(2, 10);
            Write("- Den som kommer närmast men inte över 100 efter sju kast vinner!");

            SetCursorPosition(2, 12);
            Write("  Hur många vill vara med och spela? (1-4) : ");
            numberOfPlayers = int.Parse(ReadLine());

            SetCursorPosition(0, 7);
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");

            SetCursorPosition(0, 7);

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player newPlayer = new Player();
                Write("*   Namn på spelare " + (i + 1) + ": ");
                newPlayer.name = ReadLine();
                playerList[i] = newPlayer;
            }

            Clear();

            WriteLine("*************************************************************************************************");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*************************************************************************************************");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*                                                                                               *");
            WriteLine("*************************************************************************************************");

            Console.SetCursorPosition(2, 1);

            foreach (var playerName in playerList)
            {
                if (playerName == null) continue;

                Console.Write("{0, -15}", playerName.name);
            }

            Console.SetCursorPosition(2, 2);

            for (int i = 0; i < (numberOfPlayers * 15); i++)
            {
                Console.Write("-");
            }

            Console.SetCursorPosition(2, 3);

            foreach (var playerSum in playerList)
            {
                if (playerSum == null) continue;

                Console.Write("{0, -15}", playerSum.sum);
            }
            Console.Write("{0, -15}", "           Runda " + (1 + (counterThrows / numberOfPlayers)) + " av " + numberOfThrows);

            Console.WriteLine("");

            SetCursorPosition(0, 7);
            WriteLine("*                                                                                               *");
            SetCursorPosition(2, 7);
            WriteLine("Gör er redo!");
            WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            SetCursorPosition(0, 9);
            WriteLine("*                                                                                               *");
            SetCursorPosition(2, 9);
            Write("(Tryck [Enter] för att kasta)");
            Console.ForegroundColor = ConsoleColor.Black;
            ReadLine();

            SetCursorPosition(0, 7);
            WriteLine("*                                                                                               *");

            SetCursorPosition(0, 9);
            WriteLine("*                                                                                               *");


            do
            {
                foreach (var player in playerList)
                {
                    if (player == null) continue;

                    SetCursorPosition(0, 7);
                    WriteLine("*                                                                                               *");
                    SetCursorPosition(2, 7);
                    WriteLine(player.name + ": Din tur att kasta!");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    SetCursorPosition(0, 9);
                    WriteLine("*                                                                                               *");
                    SetCursorPosition(2, 9);
                    Write("(Tryck [Enter] för att kasta)");
                    Console.ForegroundColor = ConsoleColor.Black;
                    ReadLine();

                    var r = new Random();
                    int slump = r.Next(1, 7);
                    int positionX = r.Next(1, 7);
                    int positionY = r.Next(1, 4);
                    int rotation = r.Next(1, 3);

                    int x = 0;
                    r = new Random();
                    if (positionX == 1)
                    {
                        x = r.Next(5, 85);
                    }
                    else if (positionX == 2)
                    {
                        x = r.Next(10, 65);
                    }
                    else if (positionX == 3)
                    {
                        x = r.Next(15, 45);
                    }
                    else if (positionX == 4)
                    {
                        x = r.Next(10, 45);
                    }
                    else if (positionX == 5)
                    {
                        x = r.Next(5, 35);
                    }
                    else if (positionX == 6)
                    {
                        x = r.Next(5, 65);
                    }

                    int y = 0;
                    r = new Random();
                    if (positionY == 1)
                    {
                        y = r.Next(16, 23);
                    }
                    else if (positionY == 2)
                    {
                        y = r.Next(18, 21);
                    }
                    else if (positionY == 3)
                    {
                        y = r.Next(20, 23);
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    if (rotation == 1)
                    {
                        if (slump == 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("     ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("O");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("     ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 2)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 3)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O  O  O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 4)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("           ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 5)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("     O     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 6)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O  O  O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("           ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O  O  O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }

                    }
                    else
                    {
                        if (slump == 1)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("     ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("O");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("     ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 2)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("     O     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("           ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("     O     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 3)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("     O     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("     O     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("     O     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 4)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("           ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 5)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("     O     ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }
                        else if (slump == 6)
                        {
                            Console.SetCursorPosition(x, y + 1);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 2);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 3);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 4);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("  O     O  ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();
                            Console.SetCursorPosition(x, y + 5);
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("           ");
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(2, 7);
                            WriteLine("Vill du att detta kast skall räknas som ental (E) eller tiotal (T) ?");
                            Console.SetCursorPosition(2, 9);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Write("(Tryck E för heltal eller T för tiotal)");
                            ConsoleKeyInfo keyPressed = ReadKey(true);
                            Console.ForegroundColor = ConsoleColor.Black;

                            switch (keyPressed.Key)
                            {
                                case ConsoleKey.E:
                                    {
                                        player.sum = player.sum + slump;

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.T:
                                    {
                                        player.sum = player.sum + (slump * 10);

                                        if (player.sum > maxSum)
                                        {
                                            if (player.sum < 101)
                                            {
                                                maxSum = player.sum;
                                            }
                                        }
                                    }
                                    break;
                            }

                            ClearBoard();
                        }

                    }

                    counterThrows++;

                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(2, 1);

                    foreach (var playerName in playerList)
                    {
                        if (playerName == null) continue;

                        Console.Write("{0, -15}", playerName.name);
                    }

                    Console.SetCursorPosition(2, 2);

                    for (int i = 0; i < (numberOfPlayers * 15); i++)
                    {
                        Console.Write("-");
                    }

                    Console.SetCursorPosition(2, 3);

                    foreach (var playerSum in playerList)
                    {
                        if (playerSum == null) continue;

                        Console.Write("{0, -15}", playerSum.sum);
                    }

                    if ((counterThrows / numberOfPlayers) < 7)
                    {
                        Console.Write("{0, -15}", "           Runda " + (1 + (counterThrows / numberOfPlayers)) + " av " + numberOfThrows);
                    }
                    else
                    {
                        Console.Write("{0, -15}", "           Runda 7 av " + numberOfThrows);
                    }

                    Console.SetCursorPosition(2, 4);

                    foreach (var playerCheck in playerList)
                    {
                        if (playerCheck == null) continue;

                        if (playerCheck.sum > 100)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0, -15}", "Förlust");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (playerCheck.sum == maxSum && counterThrows > ((7 * numberOfPlayers) -1))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0, -15}", "Vinnare!");
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.Write("{0, -15}", " ");
                        }
                    }

                    Console.SetCursorPosition(0, 0);
                    Console.SetCursorPosition(42, 9);


                    //Console.ReadKey();
                    Thread.Sleep(1000);

                }

            } while (counterThrows < (numberOfThrows * numberOfPlayers));

            ClearBoard();

            SetCursorPosition(0, 0);
            SetCursorPosition(0, 7);
            WriteLine("*                                                                                               *");
            SetCursorPosition(2, 8);
            WriteLine("   BRA SPELAT!");

            SetCursorPosition(0, 9);
            WriteLine("*                                                                                               *");

            SetCursorPosition(2, 10);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("   © Schneider Soloutions");

            SetCursorPosition(16, 8);


            Console.ReadKey();

        }

        static void ClearBoard()
        {
            Console.SetCursorPosition(0, 15);
            Console.BackgroundColor = ConsoleColor.White;
            
            int counterClear = 0;
            
            do
            {
                WriteLine("                                                                                                    ");
                counterClear++;
            } while (counterClear < 17);
        }

        class Player
        {
            public string name;
            public int sum;
        }
    }
}
