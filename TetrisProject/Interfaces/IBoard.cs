using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Directions;

namespace TetrisProject.Interfaces
{
    public interface IBoard
    {
        void AddTetromino(ITetromino tetromino);

        bool CheckCollision(ITetromino tetromino, Direction direction);

        void ClearLines();

        string[] GetGrid();

        int GetHeight();

        int GetWidth();
    }
}
