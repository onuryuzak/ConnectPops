using Scripts.Game.Tile.Base;
using UnityEngine;

namespace Scripts.Game.Tile.Factory
{
    public interface IGameTileFactory
    {
        GameTile Spawn(GameTile prefab, Vector3 position);
        GameTile Spawn(Vector3 position);
    }
}