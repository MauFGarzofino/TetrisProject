using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Interfaces;

namespace TetrisProject.Models
{
    public class InternalGameState
    {
        public int BoardWidth { get; }

        public int BoardHeight { get; }

        public Stopwatch Timer { get; }

        public bool CloseRequested { get; set; }

        public bool GameOver { get; set; }

        public int Score { get; set; }

        public TimeSpan FallSpeed { get; set; }

        public IBoard Board { get; set; }

        public ITetromino CurrentTetromino { get; set; }

        public ITetromino NextTetromino { get; set; }

        public bool IsInitialized { get; set; }

        public bool IsPaused { get; set; }

        public InternalGameState(int width, int height)
        {
            BoardWidth = width;
            BoardHeight = height;
            Timer = new Stopwatch();
            CloseRequested = false;
            GameOver = false;
            Score = 0;
            FallSpeed = TimeSpan.FromMilliseconds(500);
            IsInitialized = false;
            IsPaused = false;
        }

        public void Initialize(IBoard board, ITetromino currentTetromino, ITetromino nextTetromino)
        {
            GameOver = false;
            Score = 0;
            Board = board;
            CurrentTetromino = currentTetromino;
            NextTetromino = nextTetromino;
            FallSpeed = TimeSpan.FromMilliseconds(500);
            Timer.Restart();
            IsInitialized = true;
            IsPaused = false;
        }
    }
}
