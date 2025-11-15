using System;
using System.Threading;

class Program
{
    static string[,] map = {
        { "|", " ", " ", " ", "|" },
        { "|", " ", " ", " ", "|" },
        { "|", " ", " ", " ", "|" },
        { "|", " ", " ", " ", "|" },
        { "|", " ", " ", " ", "|" }
    };

    static int playerX = 2;
    static int playerY = 5;
    static int frameCounter = 0;
    // Guarda o último movimento
    static ConsoleKey lastKey;

    static List<(int x, int y)> enemies = new List<(int x, int y)>();
    static Random random = new Random();

    static int spawnCounter = 0;
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;

        while (true)
        {
            Input();
            Update();
            if(!Render())
                break;
            Console.WriteLine($"Score:{frameCounter}");

            Thread.Sleep(100);
        }
        Console.WriteLine($"\n\n💥 GAME OVER! Você bateu! SCORE FINAL: {frameCounter-1}");
        Console.ReadLine();
    }

    static void Input()
    {
        if (!Console.KeyAvailable)
            return;

        lastKey = Console.ReadKey(true).Key;
        if (lastKey == ConsoleKey.A) playerX--;
        if (lastKey == ConsoleKey.D) playerX++;
    }

    static void Update()
    {   
        frameCounter++;
        // Limita aos bounds da matriz
        if (playerX < 1) playerX = 1;
        if (playerY < 5) playerY = 5;

        // Contador para spawnar inimigos
        spawnCounter++;
        if(spawnCounter >= 10)
        {
            spawnCounter = 0;
            int enemyX = random.Next(1, map.GetLength(1) - 1);
            enemies.Add((enemyX, 0));
        }
        if(frameCounter % 5 == 0)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                enemies[i] = (enemies[i].x, enemies[i].y + 1);
            }
        }
            
        enemies.RemoveAll(e => e.y >= map.GetLength(0));

        if (playerX >= map.GetLength(1)) playerX = map.GetLength(1) - 1;
        if (playerY >= map.GetLength(0)) playerY = map.GetLength(0) - 1;

        // Evita atravessar paredes
        if (map[playerY, playerX] == "|")
        {
            if (lastKey == ConsoleKey.A) playerX++;
            if (lastKey == ConsoleKey.D) playerX--;
        }
    }
    static void WriteCell(string s)
    {
        Console.Write(s.PadRight(3));
    }

    static bool Render()
    {
        Console.SetCursorPosition(0, 0);

        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                bool printed = false;

                // Player
                if (x == playerX && y == playerY)
                {
                    WriteCell("🚘");
                    printed = true;
                    foreach (var e in enemies)
                    {
                        if (e.x == x && e.y == y)
                        { 
                            // Colisão
                            return false;
                        }
                    }
                }
                else
                {
                    // Enemies
                    foreach (var e in enemies)
                    {
                        if (e.x == x && e.y == y)
                        {
                            WriteCell("🚗");
                            printed = true;

                            // Colisão
                            if (e.x == playerX && e.y == playerY)
                                return false;

                            break;
                        }
                    }
                }

                // Mapa só imprime se ninguém ocupou a célula
                if (!printed)
                    WriteCell(map[y, x]);
            }

            Console.WriteLine();
        }

        return true;
    }


}

