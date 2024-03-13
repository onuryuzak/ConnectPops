using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Game.Tile.Base
{
    public abstract class LevelUpBehaviour : MonoBehaviour, ICanLevelUp
    {
        public abstract int CurrentLevel { get; set; }

        public abstract void LevelUp();
    }
}