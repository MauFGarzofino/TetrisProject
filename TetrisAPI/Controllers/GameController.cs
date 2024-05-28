using Microsoft.AspNetCore.Mvc;
using TetrisProject.Constants;
using TetrisProject.Services;

namespace TetrisAPI.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly Game _gameInstance;

        public GameController()
        {
            _gameInstance = Game.GetInstance(GameConfig.BoardWidht, GameConfig.BoardHeigth);
        }

        [HttpPost("start")]
        public ActionResult StartGame()
        {
            _gameInstance.InitializeGame();
            return CreatedAtAction(nameof(GetStatus), "Game initialized");
        }

        [HttpGet("status")]
        public ActionResult GetStatus()
        {
            try
            {
                return Ok(_gameInstance.GetStatus());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("pause")]
        public ActionResult PauseGame()
        {
            try
            {
                _gameInstance.Pause();
                return Ok("Game paused.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("resume")]
        public ActionResult ResumeGame()
        {
            try
            {
                _gameInstance.Resume();
                return Ok("Game resumed.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("fall")]
        public ActionResult FallTetromino()
        {
            try
            {
                _gameInstance.TetrominoFall();
                return Ok("Tetromino fallen.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("isgameover")]
        public ActionResult IsGameOver()
        {
            return Ok(_gameInstance.IsGameOver());
        }
    }
}
