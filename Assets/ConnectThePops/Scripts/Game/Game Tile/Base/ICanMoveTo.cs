using UnityEngine;

namespace Scripts.Game.Tile.Base
{
    public interface ICanMoveTo
    {
        bool IsMoving { get; }

        void MoveTo(Vector3 target);
        void MoveTo(Vector3 target, float duration);
    }
}