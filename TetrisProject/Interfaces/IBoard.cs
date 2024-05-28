using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject.Interfaces
{
    public interface IBoard
    {
        void AddTetromino(ITetromino tetromino);

        bool CheckCollision(ITetromino tetromino);

        void ClearLines();

        string[] GetGrid();

        int GetHeight();

        int GetWidth();
    }
}
