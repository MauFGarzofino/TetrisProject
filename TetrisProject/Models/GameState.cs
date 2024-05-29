using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject.Models
{
    public class GameState
    {
        public string[] Board { get; set; }

        public int Score { get; set; }

        public bool GameOver { get; set; }

        public string[] CurrentTetromino { get; set; }

        public string[] NextTetromino { get; set; }

        public int CurrentX { get; set; }

        public int CurrentY { get; set; }
    }
}
