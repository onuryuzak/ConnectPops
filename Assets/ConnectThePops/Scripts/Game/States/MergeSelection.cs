using System.Collections;
using Scripts.Game.Board;
using Scripts.Game.Selection;
using Scripts.Game.Tile;
using Scripts.Game.Tile.Base;
using Scripts.Game.Validator;
using Scripts.Game.YieldInstruction;
using Scripts.Manager;
using Scripts.State;
using UnityEngine;

namespace Scripts.Game.State
{
    public class MergeSelection : IState
    {
        private IGameBoard _gameBoard;
        private ISelection _selection;
        private IValidator _selectionValidator;

        public MergeSelection(IGameBoard gameBoard, ISelection selection)
        {
            _gameBoard = gameBoard;
            _selection = selection;
            _selectionValidator = new SelectionValidator(selection);
        }

        public IEnumerator Execute()
        {
            if (!_selectionValidator.IsValid)
            {
                _selection.Clear();
                yield break;
            }

            var sum = GetSelectionSum();
            var newLevel = (int)Mathf.Log(sum, 2);

            var last = _selection.GetLast();
            last.TileRenderer.SetRendererScale(Vector3.one);
            ClearSelectionLine();

            MoveSelected(last.transform.position);


            yield return new WaitForTileMovement(_gameBoard);

            LevelUp(last, newLevel);

            PopSelected();

            _selection.Clear();

            yield return new WaitForSeconds(0.2f);
        }

        private int GetSelectionSum()
        {
            var result = 0;

            for (var i = 0; i < _selection.Count; i++)
            {
                var tileLevel = _selection.Get(i).GetComponent<ICanLevelUp>().CurrentLevel;

                result += (int)Mathf.Pow(2, tileLevel);
            }

            return result;
        }

        private void LevelUp(GameTile gameTile, int newLevel)
        {
            if (gameTile is not ICanLevelUp canLevelUp) return;
            canLevelUp.CurrentLevel = newLevel;

            _selection.Remove(gameTile);

            if (newLevel > GameBoard.MaxReachedLevel)
            {
                GameBoard.MaxReachedLevel = newLevel;
            }
        }

        private void ClearSelectionLine()
        {
            if (_selection is LineSelection lineSelection)
            {
                lineSelection.ClearLine();
            }
        }

        private void MoveSelected(Vector3 position)
        {
            for (var i = 0; i < _selection.Count - 1; i++)
            {
                var gameTile = _selection.Get(i);

                if (gameTile is ICanMoveTo canMoveTo)
                {
                    canMoveTo.MoveTo(position, 0.2f);
                }
            }
        }

        private void PopSelected()
        {
            for (var i = 0; i < _selection.Count; i++)
            {
                var gameTile = _selection.Get(i);

                gameTile.Pop();
            }
        }
    }
}