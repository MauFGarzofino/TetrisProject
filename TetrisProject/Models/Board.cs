using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Interfaces;

namespace TetrisProject.Models
{
    public class Board : IBoard
    {
        private readonly char[][] grid;

        public int Width { get; }

        public int Height { get; }

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            grid = new char[height][];

            for (int i = 0; i < height; i++)
            {
                grid[i] = new string(' ', width).ToCharArray();
            }
        }

        public char[][] Grid => grid;

        public void AddTetromino(ITetromino tetromino)
        {
            for (int row = 0; row < tetromino.Shape.Length; row++)
            {
                for (int col = 0; col < tetromino.Shape[row].Length; col++)
                {
                    if (tetromino.Shape[row][col] != ' ' && tetromino.Shape[row][col] != '\0')
                    {
                        int x = tetromino.X + col;
                        int y = tetromino.Y + row;

                        if (x >= 0 && x < Width && y >= 0 && y < Height)
                        {
                            grid[y][x] = tetromino.Shape[row][col];
                        }
                    }
                }
            }
        }

        public bool CheckCollision(ITetromino tetromino)
        {
            for (int row = 0; row < tetromino.Shape.Length; row++)
            {
                for (int col = 0; col < tetromino.Shape[row].Length; col++)
                {
                    if (tetromino.Shape[row][col] != ' ' && tetromino.Shape[row][col] != '\0')
                    {
                        int x = tetromino.X + col;
                        int y = tetromino.Y + row;

                        if (y >= Height || x < 0 || x >= Width || (y >= 0 && grid[y][x] != ' '))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void ClearLines()
        {
            for (int row = Height - 1; row >= 0; row--)
            {
                bool isLineFull = true;
                for (int col = 0; col < Width; col++)
                {
                    if (grid[row][col] == ' ')
                    {
                        isLineFull = false;
                        break;
                    }
                }

                if (isLineFull)
                {
                    for (int r = row; r > 0; r--)
                    {
                        grid[r] = (char[])grid[r - 1].Clone();
                    }

                    grid[0] = new string(' ', Width).ToCharArray();
                    row++;
                }
            }
        }

        public string[] GetGrid()
        {
            string[] displayGrid = new string[Height];
            for (int i = 0; i < Height; i++)
            {
                displayGrid[i] = new string(grid[i]);
            }
            return displayGrid;
        }

        public int GetHeight()
        {
            return Height;
        }

        public int GetWidth()
        {
            return Width;
        }
    }
}
