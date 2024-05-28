using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisProject.Constants
{
    public static class GameConfig
    {
        public static string[] emptyField;

        static GameConfig()
        {
            InitializeEmptyField();
        }

        private static void InitializeEmptyField()
        {
            emptyField = new string[24];
            emptyField[0] = "╭──────────────────────────────╮";
            for (int i = 1; i < 23; i++)
            {
                emptyField[i] = "│                              │";
            }
            emptyField[^1] = "╰──────────────────────────────╯";
        }

        public static readonly string[] nextTetrominoBorder =
        {
            "╭─────────╮",
            "│         │",
            "│         │",
            "│         │",
            "│         │",
            "│         │",
            "│         │",
            "│         │",
            "│         │",
            "╰─────────╯",
        };

        public static readonly string[] scoreBorder =
        {
            "╭─────────╮",
            "│         │",
            "╰─────────╯",
        };

        public static readonly string[][] tetrominos =
        {
            new string[]
            {
                "╭─╮",
                "╰─╯",
                "╭─╮",
                "╰─╯",
                "╭─╮",
                "╰─╯",
                "╭─╮",
                "╰─╯"
            },
            new string[]
            {
                "╭─╮      ",
                "╰─╯      ",
                "╭─╮╭─╮╭─╮",
                "╰─╯╰─╯╰─╯",
            },
            new string[]
            {
                "      ╭─╮",
                "      ╰─╯",
                "╭─╮╭─╮╭─╮",
                "╰─╯╰─╯╰─╯",
            },
            new string[]
            {
                "╭─╮╭─╮",
                "╰─╯╰─╯",
                "╭─╮╭─╮",
                "╰─╯╰─╯",
            },
            new string[]
            {
                "   ╭─╮╭─╮",
                "   ╰─╯╰─╯",
                "╭─╮╭─╮   ",
                "╰─╯╰─╯   ",
            },
            new string[]
            {
                "   ╭─╮   ",
                "   ╰─╯   ",
                "╭─╮╭─╮╭─╮",
                "╰─╯╰─╯╰─╯",
            },
            new string[]
            {
                "╭─╮╭─╮   ",
                "╰─╯╰─╯   ",
                "   ╭─╮╭─╮",
                "   ╰─╯╰─╯",
            },
        };

        public const int BorderSize = 1;
        public const int CurrentTetronimoX = 13;
        public const int CurrentTetronimoY = 1;
        public const int ConsoleWidthMin = 44;
        public const int ConsoleHeightMin = 22;
        public const int BoardHeigth = 22;
        public const int BoardWidht = 30;

        public const int BoardX = 2;
        public const int BoardY = 1;
        public const int NextTetrominoX = 35;
        public const int NextTetrominoY = 1;
        public const int ScoreX = 35;
        public const int ScoreY = 12;

        public static readonly string MainMenu = @"

            WELCOME TO TETRIS

            Controls:
   
            [A] or [←] move left
            [D] or [→] move right
            [S] or [↓] fall faster
            [↑] spin 
            [Spacebar] drop
            [P] pause and resume
            [Escape] close game
            [Enter] start game
        ";

        public static readonly string GameOverScreen = @"



            GAME OVER 
            Final Score: {0}

            [Enter] return to menu
            [Escape] close game
        ";

        public static readonly string pauseScrenn = @"






              PAUSED   
        Press [P] to resume       
           
        ";
    }
}
