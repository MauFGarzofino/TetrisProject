using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Directions;
using TetrisProject.Interfaces;

namespace TetrisProject.Services
{
    public static class InputHandler
    {
        public static void HandlePlayerInput(IGame game)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        game.MoveCurrentTetromino(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        game.MoveCurrentTetromino(Direction.Right);
                        break;
                    case ConsoleKey.DownArrow:
                        game.MoveCurrentTetromino(Direction.Down);
                        break;
                    case ConsoleKey.UpArrow:
                        game.RotateCurrentTetromino();
                        break;
                    case ConsoleKey.Spacebar:
                        game.HardDropCurrentTetromino();
                        break;
                    case ConsoleKey.P:
                        game.Pause();
                        break;
                }
            }
        }

        public static void HandleMenuInput(ref bool mainMenuScreen, ref bool closeRequested)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        mainMenuScreen = false;
                        break;
                    case ConsoleKey.Escape:
                        closeRequested = true;
                        break;
                }
            }
        }

        public static void HandleGameOverInput(ref bool gameOverScreen, ref bool closeRequested)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Enter:
                        gameOverScreen = false;
                        break;
                    case ConsoleKey.Escape:
                        closeRequested = true;
                        break;
                }
            }
        }
    }
}
