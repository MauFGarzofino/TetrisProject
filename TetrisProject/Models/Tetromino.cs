using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Constants;
using TetrisProject.Interfaces;

namespace TetrisProject.Models
{
    public class Tetromino : ITetromino
    {
        public string[] Shape { get; set; }

        public string[] Next { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Tetromino(string[] shape, string[] next)
        {
            Shape = shape;
            Next = next;
            X = GameConfig.CurrentTetronimoX;
            Y = GameConfig.CurrentTetronimoY;
        }

        public void MoveDown()
        {
            Y += 1;
        }

        public void MoveLeft()
        {
            X -= 1;
        }

        public void MoveRight()
        {
            X += 1;
        }

        public void HardDrop()
        {
            throw new NotImplementedException();
        }

        public void Rotate()
        {
            throw new NotImplementedException();
        }

        public string[] GetShape()
        {
            string[] displayShape = new string[Shape.Length];
            for (int i = 0; i < Shape.Length; i++)
            {
                displayShape[i] = new string(Shape[i]);
            }

            return displayShape;
        }
    }
}
