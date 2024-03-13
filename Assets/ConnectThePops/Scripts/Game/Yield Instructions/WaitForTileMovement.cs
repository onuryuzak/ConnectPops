using Scripts.Game.Board;
using UnityEngine;

namespace Scripts.Game.YieldInstruction
{
    public class WaitForTileMovement : CustomYieldInstruction
    {
        GameBoardMovement _boardMovement;

        public WaitForTileMovement(IGameBoard gameBoard)
        {
            _boardMovement = new GameBoardMovement(gameBoard);
        }

        public override bool keepWaiting
        {
            get
            {
                return _boardMovement.IsAnyGameTileMoving();
            }
        }
    }
}