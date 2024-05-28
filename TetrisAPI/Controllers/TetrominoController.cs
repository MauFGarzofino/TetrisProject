using Microsoft.AspNetCore.Mvc;
using TetrisProject.Constants;
using TetrisProject.Directions;
using TetrisProject.Services;

namespace TetrisAPI.Controllers
{
    [ApiController]
    [Route("api/tetromino")]
    public class TetrominoController : ControllerBase
    {
        private readonly Game _gameInstance;

        public TetrominoController()
        {
            _gameInstance = Game.GetInstance(GameConfig.BoardWidht, GameConfig.BoardHeigth);
        }

        [HttpPost("actions/move")]
        public ActionResult MoveTetromino([FromBody] Direction direction)
        {
            try
            {
                _gameInstance.MoveCurrentTetromino(direction);
                return Ok("Tetromino moved.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("actions/rotate")]
        public ActionResult RotateTetromino()
        {
            try
            {
                _gameInstance.RotateCurrentTetromino();
                return Ok("Tetromino rotated.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("actions/drop")]
        public ActionResult HardDrop()
        {
            try
            {
                _gameInstance.HardDropCurrentTetromino();
                return Ok("Tetromino hard dropped.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
