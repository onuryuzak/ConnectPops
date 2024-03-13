using System.Collections;
using Scripts.Core;
using Scripts.Game.Board;
using Scripts.Game.Selection;
using Scripts.Game.State;
using Scripts.Manager;
using Scripts.State;
using UnityEngine;

namespace Scripts.Game.Mode
{
    public class GameMode : GameModeBase
    {
        [SerializeField] private GameBoard _gameBoard = null;

        [SerializeField] private SelectionLineRenderer _lineRenderer = null;

        ISelection _selection;

        StateQueue _queues = new StateQueue();

        private void Awake()
        {
            _selection = new LineSelection(_lineRenderer);

            _queues.Clear();
            _queues.Add(new ProcessInput(_gameBoard, _selection));
            _queues.Add(new MergeSelection(_gameBoard, _selection));
            _queues.Add(new ProcessVerticalMovement(_gameBoard));
            _queues.Add(new FillEmptyCells(_gameBoard));
        }

        void ResetBoard()
        {
            GameBoard.MaxReachedLevel = 3;
            Sum.Close();
            _gameBoard.Spawn();
        }

        public override IEnumerator StartGame()
        {
            ResetBoard();
            yield return null;
        }

        public override IEnumerator RunGame()
        {
            while (true)
            {
                yield return _queues.Execute();
            }
        }
    }
}