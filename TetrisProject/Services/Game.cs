using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisProject.Constants;
using TetrisProject.Directions;
using TetrisProject.Interfaces;
using TetrisProject.Models;

namespace TetrisProject.Services
{
    public class Game : IGame
    {
        private static Game _instance = null;
        private static readonly object _lock = new object();

        private readonly InternalGameState gameState;
        private readonly IRenderer renderer;

        public static Game GetInstance(int width, int height)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Game(width, height);
                    }
                }
            }

            return _instance;
        }

        private Game(int width, int height)
        {
            gameState = new InternalGameState(width, height);
            renderer = new Renderer();
        }

        public void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (!gameState.CloseRequested)
            {
                ShowMainMenu();
                InitializeGame();
                PlayGameLoop();
                ShowGameOverScreen();
            }

            Console.Clear();
            Console.WriteLine("Tetris was closed.");
            Console.CursorVisible = true;
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.Write(GameConfig.MainMenu);
            bool mainMenuScreen = true;
            bool closeRequested = gameState.CloseRequested;
            while (!gameState.CloseRequested && mainMenuScreen)
            {
                Console.CursorVisible = false;
                InputHandler.HandleMenuInput(ref mainMenuScreen, ref closeRequested);
            }
        }

        public void InitializeGame()
        {
            this.gameState.Initialize(new Board(gameState.BoardWidth, gameState.BoardHeight), GenerateRandomTetromino(), GenerateRandomTetromino());
        }

        private void PlayGameLoop()
        {
            Console.Clear();
            while (!gameState.CloseRequested && !gameState.GameOver)
            {
                if (Console.WindowWidth < GameConfig.ConsoleWidthMin || Console.WindowHeight < GameConfig.ConsoleHeightMin)
                {
                    Console.Clear();
                    Console.Write($"Please increase size of console to at least {GameConfig.ConsoleWidthMin}x{GameConfig.ConsoleHeightMin}. Current size is {Console.WindowWidth}x{Console.WindowHeight}.");
                    gameState.Timer.Stop();
                    while (Console.WindowWidth < GameConfig.ConsoleWidthMin || Console.WindowHeight < GameConfig.ConsoleHeightMin)
                    {
                        // Wait for the user to resize the console
                    }

                    gameState.Timer.Start();
                    Console.Clear();
                }

                renderer.DrawFrame(gameState.Board);
                renderer.DrawTetromino(gameState.CurrentTetromino);
                renderer.DrawPreview(gameState.NextTetromino);
                renderer.DrawScore(gameState.Score);

                InputHandler.HandlePlayerInput(this);

                if (gameState.CloseRequested || gameState.GameOver)
                {
                    break;
                }

                if (gameState.Timer.IsRunning && gameState.Timer.Elapsed > gameState.FallSpeed)
                {
                    TetrominoFall();
                    if (gameState.CloseRequested || gameState.GameOver)
                    {
                        break;
                    }
                }

                Thread.Sleep(300);
            }
        }

        private void ShowGameOverScreen()
        {
            Console.Clear();
            Console.Write(string.Format(GameConfig.GameOverScreen, gameState.Score));
            Console.CursorVisible = false;
            bool gameOverScreen = true;
            bool closeRequested = gameState.CloseRequested;
            while (!gameState.CloseRequested && gameOverScreen)
            {
                Console.CursorVisible = false;
                InputHandler.HandleGameOverInput(ref gameOverScreen, ref closeRequested);
            }
        }

        public void MoveCurrentTetromino(Direction direction)
        {
            if (!this.gameState.IsInitialized)
            {
                throw new InvalidOperationException("Game not initialized.");
            }

            switch (direction)
            {
                case Direction.Left:
                    gameState.CurrentTetromino.MoveLeft();
                    break;
                case Direction.Right:
                    gameState.CurrentTetromino.MoveRight();
                    break;
                case Direction.Down:
                    gameState.CurrentTetromino.MoveDown();
                    break;
            }
        }

        public void RotateCurrentTetromino()
        {
            if (!gameState.IsInitialized)
            {
                throw new InvalidOperationException("Game not initialized.");
            }
            try
            {
                gameState.CurrentTetromino.Rotate();
            }
            catch (NotImplementedException)
            {
                throw new InvalidOperationException("Rotate operation is not implemented.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to rotate tetromino: {ex.Message}", ex);
            }
        }

        public void HardDropCurrentTetromino()
        {
            if (!gameState.IsInitialized)
            {
                throw new InvalidOperationException("Game not initialized.");
            }
            try
            {
                gameState.CurrentTetromino.HardDrop();
            }
            catch (NotImplementedException)
            {
                throw new InvalidOperationException("Hard drop operation is not implemented.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to hard drop tetromino: {ex.Message}", ex);
            }
        }

        private ITetromino GenerateRandomTetromino()
        {
            Random rand = new Random();
            int index = rand.Next(GameConfig.tetrominos.Length);
            string[] shape = GameConfig.tetrominos[index];
            string[] nextShape = GameConfig.tetrominos[(index + 1) % GameConfig.tetrominos.Length];
            return new Tetromino(shape, nextShape);
        }

        public void TetrominoFall()
        {
            if (CanMoveDown(gameState.CurrentTetromino))
            {
                gameState.CurrentTetromino.MoveDown();
            }
            else
            {
                gameState.Board.AddTetromino(gameState.CurrentTetromino);
                gameState.Board.ClearLines();
                gameState.Score += 1;

                if (IsGameOver() && gameState.Score == 10)
                {
                    gameState.GameOver = true;
                    return;
                }

                gameState.CurrentTetromino = gameState.NextTetromino;
                gameState.NextTetromino = GenerateRandomTetromino();
            }

            gameState.Timer.Restart();
        }

        public bool CanMoveDown(ITetromino tetromino)
        {
            var testTetromino = new Tetromino(tetromino.Shape, tetromino.Next)
            {
                X = tetromino.X,
                Y = tetromino.Y + 1
            };

            return !gameState.Board.CheckCollision(testTetromino);
        }

        public bool IsGameOver()
        {
            foreach (var row in gameState.CurrentTetromino.Shape)
            {
                for (int col = 0; col < row.Length; col++)
                {
                    if (row[col] != ' ' && row[col] != '\0')
                    {
                        int x = gameState.CurrentTetromino.X + col;
                        int y = gameState.CurrentTetromino.Y;

                        if (y < 0 || gameState.Board.CheckCollision(gameState.CurrentTetromino))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void Pause()
        {
            if (!gameState.IsInitialized)
            {
                throw new InvalidOperationException("Game not initialized.");
            }

            gameState.Timer.Stop();
            gameState.IsPaused = true;
            renderer.DrawPauseScreen();

            if (!gameState.IsPaused)
            {
                while (Console.ReadKey(true).Key != ConsoleKey.P)
                {
                }

                gameState.Timer.Start();
            }
        }

        public void Resume()
        {
            if (!gameState.IsInitialized)
            {
                throw new InvalidOperationException("Game not initialized.");
            }

            if (!gameState.IsPaused)
            {
                throw new InvalidOperationException("Game is not paused.");
            }

            gameState.Timer.Start();
            gameState.IsPaused = false;
        }

        public GameState GetStatus()
        {
            if (!gameState.IsInitialized)
            {
                throw new InvalidOperationException("Game not initialized.");
            }
            return new GameState
            {
                Board = gameState.Board.GetGrid(),
                Score = gameState.Score,
                GameOver = gameState.GameOver,
                CurrentTetromino = gameState.CurrentTetromino.GetShape(),
                NextTetromino = gameState.NextTetromino.GetShape(),
                CurrentX = gameState.CurrentTetromino.X,
                CurrentY = gameState.CurrentTetromino.Y
            };
        }
    }
}
