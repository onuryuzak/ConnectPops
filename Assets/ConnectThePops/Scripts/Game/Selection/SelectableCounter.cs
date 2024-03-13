using System.Collections.Generic;
using Scripts.Game.Tile;
using Scripts.Game.Tile.Base;
using Scripts.Game.Validator;
using Scripts.Grid;
using UnityEngine;

namespace Scripts.Game.Selection
{
    public class SelectableCounter
    {
        IGameGrid _grid;
        IConnectionValidator _connectionValidator;

        Vector2[] _directions;

        Selection _selection;

        public SelectableCounter(IGameGrid grid)
        {
            this._selection = new Selection();
            this._selection.Clear();

            this._grid = grid;

            this._connectionValidator = new LevelValidator(_selection);

            _directions = new Vector2[]
            {
                Vector2.up,
                Vector2.right + Vector2.up/2,
                Vector2.right + Vector2.down/2,
                Vector2.down,
                Vector2.left+ Vector2.up/2,
                Vector2.left + Vector2.down/2,
            };
        }
        public int Count(GameTile gameTile)
        {
            _selection.Clear();

            if (gameTile != null && !gameTile.IsDestroyed)
            {
                AddToSelection(gameTile);
            }

            return _selection.Count;
        }

        public void AddToSelection(GameTile gameTile)
        {
            if (_selection.Contains(gameTile))
            {
                return;
            }

            _selection.Add(gameTile);

            gameTile.DisableCollider();

            foreach (var direction in _directions)
            {
                TrySelect(gameTile, direction);
            }

            gameTile.EnableCollider();
        }

        public void TrySelect(GameTile gameTile, Vector2 direction)
        {
            float maxDistance = Mathf.Sqrt(2 * _grid.CellSize * _grid.CellSize);

            var raycast = new GameTileRaycast(gameTile.transform.position, direction, maxDistance);

            if (raycast.Perform(out var neighbor))
            {
                if (_connectionValidator.IsValid(gameTile, neighbor))
                {
                    AddToSelection(neighbor);
                }
            }
        }
    }
}