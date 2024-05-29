using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Directions;

namespace TetrisProject.Interfaces
{
    public interface IGame
    {
        void Start();

        void Pause();

        void Resume();

        void MoveCurrentTetromino(Direction direction);

        void RotateCurrentTetromino();

        void HardDropCurrentTetromino();
    }
}
