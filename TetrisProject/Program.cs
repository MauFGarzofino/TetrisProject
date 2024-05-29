using System;
using TetrisProject.Constants;
using TetrisProject.Services;


class Program
{
    static void Main()
    {
        Game game1 = Game.GetInstance(GameConfig.BoardWidht, GameConfig.BoardHeigth);
        Game game2 = Game.GetInstance(GameConfig.BoardWidht, GameConfig.BoardHeigth);

        if (game1 == game2)
        {
            Console.WriteLine("Singleton works, both variables contain the same instance.");
        }
        else
        {
            Console.WriteLine("Singleton failed, variables contain different instances.");
        }

        game1.Start();
    }
}
