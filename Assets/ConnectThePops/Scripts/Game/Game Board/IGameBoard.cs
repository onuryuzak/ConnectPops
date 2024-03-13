using System.Collections.Generic;
using Scripts.Game.Tile.Base;
using Scripts.Game.Tile.Factory;
using Scripts.Grid;

namespace Scripts.Game.Board
{
    public interface IGameBoard : IGameGrid, IGameTileFactory
    {
        IList<GameTile> GameTiles { get; }
    }
}