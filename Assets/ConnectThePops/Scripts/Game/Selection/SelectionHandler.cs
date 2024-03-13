using System.Collections.Generic;
using System.Linq;
using Scripts.Game.Tile;
using Scripts.Game.Tile.Base;
using Scripts.Game.Validator;
using Scripts.Grid;
using UnityEngine;

namespace Scripts.Game.Selection
{
    public class SelectionHandler : ISelectionHandler
    {
        private ISelection _selection;

        private List<IConnectionValidator> _connectionValidators;

        public SelectionHandler(IGameGrid grid, ISelection selection)
        {
            _selection = selection;

            _connectionValidators = new List<IConnectionValidator>()
            {
                new LevelValidator(selection),
                new GridDistanceValidator(grid)
            };
        }

        public void ReleaseSelection()
        {
            for (int i = 0; i < _selection.Count; i++)
            {
                _selection.Get(i).TileRenderer.SetRendererScale(Vector3.one);
            }
        }

        public void HandleSelection(GameTile gameTile)
        {
            if (IsSelectable(gameTile))
            {
                gameTile.TileRenderer.SetRendererScale(Vector3.one * 1.2f);
                _selection.Add(gameTile);
            }
            else if (IsSecondToLast(gameTile))
            {
                _selection.GetLast().TileRenderer.SetRendererScale(Vector3.one);
                _selection.Remove(_selection.GetLast());
            }

            Sum.Show(SumValue());
        }


        public int GetSelectionSum()
        {
            var result = 0;

            for (var i = 0; i < _selection.Count; i++)
            {
                var tileLevel = _selection.Get(i).GetComponent<ICanLevelUp>().CurrentLevel;

                result += (int)Mathf.Pow(2, tileLevel);
            }

            return result;
        }

        private float SumValue()
        {
            var sum = GetSelectionSum();
            var newLevel = (int)Mathf.Log(sum, 2);
            var value = (Mathf.Pow(2f, newLevel + 1));
            return value;
        }

        private bool IsSelectable(GameTile gameTile)
        {
            if (_selection.Contains(gameTile))
            {
                return false;
            }

            return _selection.Count == 0 || AreConnectable(_selection.GetLast(), gameTile);
        }

        private bool IsSecondToLast(GameTile gameTile)
        {
            return _selection.Count > 1 && _selection.Get(_selection.Count - 2) == gameTile;
        }

        private bool AreConnectable(GameTile gameTile1, GameTile gameTile2)
        {
            return _connectionValidators.All(validator => validator.IsValid(gameTile1, gameTile2));
        }
    }
}