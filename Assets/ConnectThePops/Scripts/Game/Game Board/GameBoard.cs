using System.Collections.Generic;
using Scripts.Game.Tile;
using Scripts.Game.Tile.Base;
using Scripts.Game.Tile.Factory;
using Scripts.Grid;
using UnityEngine;

namespace Scripts.Game.Board
{
    public class GameBoard : GameGrid, IGameBoard
    {
        public static int MaxReachedLevel = 3;

        [SerializeField] private AbstractGameTileFactory gameTileFactory = null;

        public IList<GameTile> GameTiles => GameTileManager.Instance.GameTiles;

        public GameTile Spawn(GameTile prefab, Vector3 position)
        {
            var gameTile = gameTileFactory.Spawn(position);
            gameTile.transform.localScale *= CellSize;
            return gameTile;
        }

        public GameTile Spawn(Vector3 position)
        {
            var gameTile = gameTileFactory.Spawn(position);
            gameTile.transform.localScale *= CellSize;
            return gameTile;
        }

        public void Spawn()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    var position = GetPosition(x, y);
                    Spawn(position);
                }
            }
        }
    }
}