using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject.Interfaces
{
    public interface ITetromino
    {
        string[] Shape { get; set; }

        string[] Next { get; set; }

        int X { get; set; }

        int Y { get; set; }

        void MoveLeft();

        void MoveRight();

        void MoveDown();

        void Rotate();

        void HardDrop(IBoard board);

        string[] GetShape();
    }
}
