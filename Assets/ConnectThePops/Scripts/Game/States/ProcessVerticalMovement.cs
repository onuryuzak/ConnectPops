using System.Collections;
using System.Collections.Generic;
using Scripts.Game.Board;
using Scripts.Game.Tile;
using Scripts.Game.Tile.Base;
using Scripts.Game.YieldInstruction;
using Scripts.State;
using UnityEngine;

namespace Scripts.Game.State
{
    public class ProcessVerticalMovement : IState
    {
        private GameBoard _gameBoard;

        private List<GameObject> _processedGameTiles;

        public ProcessVerticalMovement(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
            _processedGameTiles = new List<GameObject>();
        }

        public IEnumerator Execute()
        {
            PushGameTilesDown();

            yield return new WaitForTileMovement(_gameBoard);
        }
        void PushGameTilesDown()
        {
            _processedGameTiles.Clear();

            for (int x = 0; x < _gameBoard.Width; x++)
            {
                PushGameTilesInColumnDown(x);
            }
        }
        void PushGameTilesInColumnDown(int column)
        {
            for (int y = 0; y < _gameBoard.Height; y++)
            {
                if (IsCellEmptyOrProcessed(column, y))
                {
                    if (TryGetNextUpperGameTile(column, y, out GameTile gameTile))
                    {
                        if (gameTile is ICanMoveTo canMoveTo)
                        {
                            canMoveTo.MoveTo(_gameBoard.GetPosition(column, y));
                        }

                        _processedGameTiles.Add(gameTile.gameObject);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        bool IsCellEmptyOrProcessed(int x, int y)
        {
            var raycast = new GameTileRaycast(_gameBoard.GetPosition(x, y), Vector2.zero, 0);

            if (TryGetGameTile(_gameBoard.GetPosition(x, y), out var gameTile))
            {
                if (_processedGameTiles.Contains(gameTile.gameObject))
                {
                    return true;
                }

                return false;
            }

            return true;
        }
        bool TryGetNextUpperGameTile(int x, int y, out GameTile gameTile)
        {
            gameTile = null;

            for (int h = y + 1; h <= _gameBoard.Height; h++)
            {
                if (TryGetGameTile(_gameBoard.GetPosition(x, h), out gameTile))
                {
                    if (gameTile.IsDestroyed || _processedGameTiles.Contains(gameTile.gameObject))
                    {
                        continue;
                    }

                    return true;
                }
            }

            return false;
        }

        bool TryGetGameTile(Vector2 position, out GameTile gameTile)
        {
            var raycast = new GameTileRaycast(position, Vector2.zero, 0);

            return raycast.Perform(out gameTile);
        }
    }
}