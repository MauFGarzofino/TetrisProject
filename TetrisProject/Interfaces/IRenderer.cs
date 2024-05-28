using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject.Interfaces
{
    public interface IRenderer
    {
        void DrawFrame(IBoard board);

        void DrawTetromino(ITetromino tetromino);

        void DrawPreview(ITetromino nextTetromino);

        void DrawScore(int score);

        void DrawPauseScreen();
    }
}
