using Scripts.Game.Tile.Base;
using UnityEngine;

namespace Scripts.Game.Tile.Factory
{
    public abstract class AbstractGameTileFactory : MonoBehaviour, IGameTileFactory
    {
        public abstract GameTile Spawn(GameTile prefab, Vector3 position);
        public abstract GameTile Spawn(Vector3 position);
    }
}