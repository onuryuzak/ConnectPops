using System.Collections.Generic;
using Scripts.Game.Board;
using Scripts.Game.Tile;
using Scripts.Game.Tile.Base;
using Scripts.Utility;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scripts.Game.Tile.Factory
{
    public class GameTileFactory : AbstractGameTileFactory
    {
        [SerializeField] private List<GameTile> _prefabs = new List<GameTile>();

        private GameTileManager GameTileManager => GameTileManager.Instance;

        private GameObject _gameTileContainer;

        void Awake()
        {
            _gameTileContainer = new GameObject("Game Tiles");
            _gameTileContainer.transform.position = new Vector3(0, 1f, 0);
        }

        public override GameTile Spawn(Vector3 position)
        {
            var prefab = _prefabs.GetRandom();

            return Spawn(prefab, position);
        }

        public override GameTile Spawn(GameTile prefab, Vector3 position)
        {
            var gameTile = Instantiate(prefab, position, Quaternion.identity);

            gameTile.transform.SetParent(_gameTileContainer.transform);

            GameTileManager.Subscribe(gameTile);

            if (gameTile.TryGetComponent<TileLevelBehaviour>(out var tileLevel))
            {
                tileLevel.SetLevel(Random.Range(0, GameBoard.MaxReachedLevel - 1));
            }

            return gameTile;
        }
    }
}