using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Constants;
using TetrisProject.Interfaces;

namespace TetrisProject.Services
{
    public class Renderer : IRenderer
    {
        public void DrawFrame(IBoard board)
        {
            Console.Clear();

            // Draw the empty board
            for (int y = 0; y < GameConfig.emptyField.Length; y++)
            {
                Console.SetCursorPosition(GameConfig.BoardX, GameConfig.BoardY + y);
                Console.WriteLine(GameConfig.emptyField[y]);
            }

            // Draw the board's content
            string[] grid = board.GetGrid();
            for (int y = 0; y < grid.Length; y++)
            {
                Console.SetCursorPosition(GameConfig.BoardX + 1, GameConfig.BoardY + 1 + y);
                Console.WriteLine(grid[y]);
            }

            // Draw the border of the next tetromino
            for (int y = 0; y < GameConfig.nextTetrominoBorder.Length; y++)
            {
                Console.SetCursorPosition(GameConfig.NextTetrominoX, GameConfig.NextTetrominoY + y);
                Console.WriteLine(GameConfig.nextTetrominoBorder[y]);
            }

            // Draw the border of the scoreboard
            for (int y = 0; y < GameConfig.scoreBorder.Length; y++)
            {
                Console.SetCursorPosition(GameConfig.ScoreX, GameConfig.ScoreY + y);
                Console.WriteLine(GameConfig.scoreBorder[y]);
            }
        }

        public void DrawPauseScreen()
        {
            Console.Clear();
            Console.Write(GameConfig.pauseScrenn);
        }

        public void DrawPreview(ITetromino nextTetromino)
        {
            for (int y = 0; y < nextTetromino.Shape.Length; y++)
            {
                Console.SetCursorPosition(GameConfig.NextTetrominoX + 1, GameConfig.NextTetrominoY + 1 + y);
                Console.WriteLine(nextTetromino.Shape[y]);
            }
        }

        public void DrawScore(int score)
        {
            Console.SetCursorPosition(GameConfig.ScoreX + 1, GameConfig.ScoreY + 1);
            Console.WriteLine($"Score: {score}");
        }

        public void DrawTetromino(ITetromino tetromino)
        {
            for (int y = 0; y < tetromino.Shape.Length; y++)
            {
                Console.SetCursorPosition(GameConfig.BoardX + tetromino.X, GameConfig.BoardY + tetromino.Y + y);
                Console.WriteLine(tetromino.Shape[y]);
            }
        }
    }
}
