using System.Collections.Generic;
using Scripts.Core;
using Scripts.Game.Tile.Base;

namespace Scripts.Game.Tile
{
    public class GameTileManager : SingletonBehaviour<GameTileManager>
    {
        public List<GameTile> GameTiles { get; } = new List<GameTile>();

        public void Subscribe(GameTile gameTile)
        {
            gameTile._OnTileDestroyed += OnGameTileDestroy;
            GameTiles.Add(gameTile);
        }

        public void UnSubscribe(GameTile gameTile)
        {
            gameTile._OnTileDestroyed -= OnGameTileDestroy;
            GameTiles.Remove(gameTile);
        }

        private void OnGameTileDestroy(GameTile gameTile)
        {
            UnSubscribe(gameTile);
        }
    }
}