using UnityEngine.Events;

namespace Scripts.Game.Tile.Base
{
    public interface ICanLevelUp
    {
        int CurrentLevel { get; set; }

        void LevelUp();
    }
}