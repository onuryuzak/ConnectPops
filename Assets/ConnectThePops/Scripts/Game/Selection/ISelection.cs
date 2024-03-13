using Scripts.Game.Tile.Base;
using UnityEngine;

namespace Scripts.Game.Selection
{
    public interface ISelection
    {
        void Clear();

        bool IsLast(GameTile gameTile);

        bool Contains(GameTile gameTile);

        bool IsEmpty { get; }

        void Add(GameTile gameTile);

        void Remove(GameTile gameTile);

        int Count { get; }

        GameTile Get(int index);

        GameTile GetLast();

        Color32 GetColor();
    }
}