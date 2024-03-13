using System;
using System.Collections;
using Scripts.Game.Selection;
using Scripts.Game.Tile.Base;
using Scripts.Grid;
using Scripts.Manager;
using Scripts.State;
using UnityEngine;

namespace Scripts.Game.State
{
    public class ProcessInput : IState
    {
        private MouseInput _mouseInput;
        private ISelectionHandler _selectionHandler;
        private GameTile _lastSelectedTile = null;

        public ProcessInput(IGameGrid grid, ISelection selection)
        {
            _selectionHandler = new SelectionHandler(grid, selection);

            _mouseInput = new MouseInput(Camera.main);
        }

        public IEnumerator Execute()
        {
            while (_mouseInput.IsLeftButtonDown())
            {
                if (_mouseInput.IsHitObject<GameTile>(out var gameTile))
                {
                    _selectionHandler.HandleSelection(gameTile);
                }
                yield return new WaitForEndOfFrame();
            }

            Sum.Close();
            _selectionHandler.ReleaseSelection();
        }
    }
}