using Scripts.Game.Tile.Base;
using UnityEngine;

namespace Scripts.Game.Tile
{
    public class Tile : GameTile, ICanLevelUp, ICanMoveTo
    {
        [SerializeField] private LevelUpBehaviour _levelUpBehaviour = null;

        [SerializeField] private MoveToBehaviour _moveToBehaviour = null;

        public int CurrentLevel
        {
            get => _levelUpBehaviour.CurrentLevel;
            set => _levelUpBehaviour.CurrentLevel = value;
        }

        public bool IsMoving => _moveToBehaviour.IsMoving;

        public void LevelUp() => _levelUpBehaviour.LevelUp();

        public void MoveTo(Vector3 target)
        {
            _moveToBehaviour.MoveTo(target);
        }

        public void MoveTo(Vector3 target, float duration)
        {
            _moveToBehaviour.MoveTo(target, duration);
        }

        void Reset()
        {
            _levelUpBehaviour = GetComponentInChildren<LevelUpBehaviour>();
            _moveToBehaviour = GetComponentInChildren<MoveToBehaviour>();
        }
    }
}